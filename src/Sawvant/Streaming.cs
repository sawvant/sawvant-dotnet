using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Sawvant;

public record StreamEvent(string Type, JobResponse Data);

public static class Streaming
{
    /// <summary>
    /// Stream job progress via Server-Sent Events.
    /// </summary>
    public static async IAsyncEnumerable<StreamEvent> StreamJobAsync(
        string jobId,
        string apiKey,
        string baseUrl = "https://api.sawvant.com",
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        using var client = new HttpClient();
        var url = $"{baseUrl}/v1/jobs/{jobId}/stream";

        using var request = new HttpRequestMessage(HttpMethod.Get, url);
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
                yield return new StreamEvent(currentEvent, data);
            }
        }
    }
}
