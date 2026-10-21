# Sawvant .NET SDK

The official C# client for the [Sawvant](https://sawvant.com) Cutting Optimization API.

- API version: 1.0.0
- Package version: 0.1.0
- Targets: .NET 8.0 and later

## Installation

```sh
dotnet add package Sawvant
```

Or via the NuGet Package Manager:

```
Install-Package Sawvant
```

## Quick Start

The SDK plugs into the .NET generic host. `ConfigureApi` registers the API classes and their `HttpClient`s; you take them from the service provider.

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sawvant.Api;
using Sawvant.Client;
using Sawvant.Extensions;
using Sawvant.Model;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureApi((context, services, options) =>
    {
        // The API key goes in the X-API-Key header without a prefix.
        options.AddTokens(new ApiKeyToken("sk_your_api_key_here", ClientUtils.ApiKeyHeader.X_API_Key, prefix: ""));
    })
    .Build();

var optimizationApi = host.Services.GetRequiredService<IOptimizationApi>();
var jobsApi = host.Services.GetRequiredService<IJobsApi>();

// Submit an optimization job. Sizes are in mm.
var request = new OptimizeRequest(
    sheets: new List<Sheet>
    {
        new Sheet(id: "board", length: 2800, width: 2070, quantity: 10, grain: GrainDirection.None),
    },
    parts: new List<Part>
    {
        new Part(id: "panel-a", length: 600, width: 400, quantity: 10, grain: GrainDirection.None),
        new Part(id: "panel-b", length: 300, width: 200, quantity: 20, grain: GrainDirection.None),
    },
    machine: new Machine(bladeThickness: 4.4, maxLevels: 3, cutDirection: CutDirection.Default)
);

var created = await optimizationApi.CreateOptimizationAsync(request);
var job = created.Accepted() ?? throw new Exception($"Create failed: {created.StatusCode} {created.RawContent}");
Console.WriteLine($"Job created: {job.JobId}");

// Poll for results
JobResponse result;
do
{
    await Task.Delay(TimeSpan.FromSeconds(1));
    var response = await jobsApi.GetJobAsync(job.JobId);
    result = response.Ok() ?? throw new Exception($"Get job failed: {response.StatusCode}");
}
while (result.Status is JobResponse.StatusEnum.Pending or JobResponse.StatusEnum.Running);

if (result.Status == JobResponse.StatusEnum.Completed)
{
    Console.WriteLine($"Optimization complete: {result.Result}");
}
else
{
    Console.WriteLine($"Job failed: {result.Error}");
}
```

Every method returns a response object. `Accepted()` or `Ok()` gives the parsed body for a success status and `null` otherwise; `StatusCode` and `RawContent` hold the raw response.

## SSE Streaming

Stream real-time progress events as the job runs with `Sawvant.Streaming.StreamJobAsync`, which returns an `IAsyncEnumerable<StreamEvent>`. Pass the job ID that `CreateOptimizationAsync` returned:

```csharp
using Sawvant;

var apiKey = Environment.GetEnvironmentVariable("SAWVANT_API_KEY")!;
var jobId = "550e8400-e29b-41d4-a716-446655440000";

await foreach (var evt in Streaming.StreamJobAsync(jobId, apiKey))
{
    switch (evt.Type)
    {
        case "progress":
            Console.WriteLine($"Progress: {evt.Data.Progress}%");
            break;
        case "completed":
            Console.WriteLine($"Done: {evt.Data.Result}");
            return;
        case "failed":
            throw new Exception($"Job failed: {evt.Data.Error}");
    }
}
```

`StreamJobAsync` also takes an optional `baseUrl` (default `https://api.sawvant.com`) and a `CancellationToken`.

When a `completed` event arrives, the SDK fetches the full job via `GET /v1/jobs/{id}` and puts it in the event, so `evt.Data.Result` holds the complete result. The server leaves the result out of stream events to keep them small. Other events are passed on as received.

## Configuration

`AddApiHttpClients` sets the base address and lets you configure the `HttpClient`s, for example for a timeout or a retry policy:

```csharp
using Microsoft.Extensions.Hosting;
using Sawvant.Client;
using Sawvant.Extensions;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureApi((context, services, options) =>
    {
        var apiKey = Environment.GetEnvironmentVariable("SAWVANT_API_KEY")!;
        options.AddTokens(new ApiKeyToken(apiKey, ClientUtils.ApiKeyHeader.X_API_Key, prefix: ""));
        options.AddApiHttpClients(
            client =>
            {
                client.BaseAddress = new Uri("https://api.sawvant.com");
                client.Timeout = TimeSpan.FromSeconds(30);
            },
            builder => builder.AddRetryPolicy(3));
    })
    .Build();
```

| Setting | Description |
|---------|-------------|
| `ApiKeyToken` | Your `sk_...` API key, sent in the `X-API-Key` header. Pass `prefix: ""`. |
| `client.BaseAddress` | API base URL (default: `https://api.sawvant.com`) |
| `client.Timeout` | Request timeout |
| `AddRetryPolicy`, `AddTimeoutPolicy`, `AddCircuitBreakerPolicy` | Polly policies on the `IHttpClientBuilder` |

## API Reference

All endpoints are relative to `https://api.sawvant.com`.

| Interface | Method | HTTP | Path | Description |
|-----------|--------|------|------|-------------|
| `IOptimizationApi` | `CreateOptimizationAsync` | POST | `/v1/optimize` | Submit a new cutting optimization job |
| `IOptimizationApi` | `CreateBatchOptimizationAsync` | POST | `/v1/optimize/batch` | Submit several optimization jobs at once |
| `IJobsApi` | `GetJobAsync` | GET | `/v1/jobs/{id}` | Retrieve job status and result |
| `IJobsApi` | `GetJobDiagramSVGAsync` | GET | `/v1/jobs/{id}/diagram` | Cutting diagram as SVG |
| `IJobsApi` | `GetJobDiagramPDFAsync` | GET | `/v1/jobs/{id}/diagram.pdf` | Cutting diagram as PDF |
| `Streaming` | `StreamJobAsync` | GET | `/v1/jobs/{id}/stream` | Stream job progress via SSE |
| `ISystemApi` | `GetHealthAsync` | GET | `/health` | Health check (no auth required) |
| `ISystemApi` | `ListTiersAsync` | GET | `/v1/tiers` | List subscription tiers (no auth required) |

## License

Apache-2.0. See [LICENSE](LICENSE).
