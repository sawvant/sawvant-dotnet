using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Sawvant.Model;

namespace Sawvant;

public record StreamEvent(string Type, JobResponse Data);

public static class Streaming
{
    /// <summary>
    /// Stream job progress via Server-Sent Events.
    /// </summary>
    /// <remarks>
    /// SSE events emitted by the server intentionally omit the full OptimizeResult
    /// to avoid buffer overflow on large result payloads. When a "completed" event
    /// is received, the SDK automatically fetches the full job via
    /// GET /v1/jobs/{id} and replaces the SSE-parsed data with the complete
    /// JobResponse before delivering it to the caller. All other event types are
    /// forwarded as-is.
    /// </remarks>
    public static async IAsyncEnumerable<StreamEvent> StreamJobAsync(
        string jobId,
        string apiKey,
        string baseUrl = "https://api.sawvant.com",
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        using var client = new HttpClient();
        var streamUrl = $"{baseUrl}/v1/jobs/{jobId}/stream";

        using var request = new HttpRequestMessage(HttpMethod.Get, streamUrl);
        request.Headers.Add("X-API-Key", apiKey);
        request.Headers.Add("Accept", "text/event-stream");

        using var response = await client.SendAsync(
            request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
        response.EnsureSuccessStatusCode();

        using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        using var reader = new StreamReader(stream);

        var currentEvent = "";

        while (!reader.EndOfStream)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var line = await reader.ReadLineAsync(cancellationToken);
            if (line == null) break;

            if (line.StartsWith("event:"))
            {
                currentEvent = line[6..].Trim();
            }
            else if (line.StartsWith("data:"))
            {
                var json = line[5..].Trim();
                var data = JsonSerializer.Deserialize<JobResponse>(json)!;

                // SSE events don't include the full result to avoid buffer overflow;
                // fetch via REST instead.
                if (currentEvent == "completed")
                {
                    data = await FetchFullJobAsync(client, baseUrl, jobId, apiKey, cancellationToken);
                }

                yield return new StreamEvent(currentEvent, data);
            }
        }
    }

    /// <summary>
    /// Fetches the full job response via GET /v1/jobs/{id} after SSE completion.
    /// </summary>
    private static async Task<JobResponse> FetchFullJobAsync(
        HttpClient client,
        string baseUrl,
        string jobId,
        string apiKey,
        CancellationToken cancellationToken)
    {
        var url = $"{baseUrl}/v1/jobs/{jobId}";
        using var req = new HttpRequestMessage(HttpMethod.Get, url);
        req.Headers.Add("X-API-Key", apiKey);
        req.Headers.Add("Accept", "application/json");

        using var resp = await client.SendAsync(req, cancellationToken);
        resp.EnsureSuccessStatusCode();

        var body = await resp.Content.ReadAsStringAsync(cancellationToken);
        return JsonSerializer.Deserialize<JobResponse>(body)
            ?? throw new InvalidOperationException("Failed to deserialize job response from REST endpoint");
    }
}
