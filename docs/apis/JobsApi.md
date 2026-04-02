# Sawvant.Api.JobsApi

All URIs are relative to *https://api.sawvant.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetJob**](JobsApi.md#getjob) | **GET** /v1/jobs/{id} | Get job status |
| [**StreamJob**](JobsApi.md#streamjob) | **GET** /v1/jobs/{id}/stream | Stream job progress via SSE |

<a id="getjob"></a>
# **GetJob**
> JobResponse GetJob (Guid id)

Get job status

Returns the current state of a job including progress, result, and errors.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Sawvant.Api;
using Sawvant.Client;
using Sawvant.Model;

namespace Example
{
    public class GetJobExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.sawvant.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("X-API-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("X-API-Key", "Bearer");

            var apiInstance = new JobsApi(config);
            var id = "id_example";  // Guid | Job UUID

            try
            {
                // Get job status
                JobResponse result = apiInstance.GetJob(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling JobsApi.GetJob: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetJobWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get job status
    ApiResponse<JobResponse> response = apiInstance.GetJobWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling JobsApi.GetJobWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** | Job UUID |  |

### Return type

[**JobResponse**](JobResponse.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Job found |  -  |
| **400** | Invalid job ID format |  -  |
| **401** | Missing or invalid API key |  -  |
| **404** | Job not found |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="streamjob"></a>
# **StreamJob**
> string StreamJob (Guid id)

Stream job progress via SSE

Server-Sent Events stream that emits `progress`, `completed`, or `failed` events. The stream closes automatically when the job reaches a terminal state.  A `: heartbeat` comment is sent every 30 seconds to keep the connection alive through proxies and load balancers. SSE clients ignore these automatically. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Sawvant.Api;
using Sawvant.Client;
using Sawvant.Model;

namespace Example
{
    public class StreamJobExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.sawvant.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("X-API-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("X-API-Key", "Bearer");

            var apiInstance = new JobsApi(config);
            var id = "id_example";  // Guid | Job UUID

            try
            {
                // Stream job progress via SSE
                string result = apiInstance.StreamJob(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling JobsApi.StreamJob: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the StreamJobWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Stream job progress via SSE
    ApiResponse<string> response = apiInstance.StreamJobWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling JobsApi.StreamJobWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** | Job UUID |  |

### Return type

**string**

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/event-stream, application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | SSE event stream |  -  |
| **400** | Invalid job ID format |  -  |
| **401** | Missing or invalid API key |  -  |
| **404** | Job not found |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

