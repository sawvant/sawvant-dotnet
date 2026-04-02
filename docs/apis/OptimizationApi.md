# Sawvant.Api.OptimizationApi

All URIs are relative to *https://api.sawvant.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateOptimization**](OptimizationApi.md#createoptimization) | **POST** /v1/optimize | Submit a cutting optimization job |

<a id="createoptimization"></a>
# **CreateOptimization**
> OptimizeAccepted CreateOptimization (OptimizeRequest optimizeRequest)

Submit a cutting optimization job

Validates the request synchronously, then enqueues the job for async processing. Returns 202 with a job ID and URLs for polling/streaming. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Sawvant.Api;
using Sawvant.Client;
using Sawvant.Model;

namespace Example
{
    public class CreateOptimizationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.sawvant.com";
            // Configure API key authorization: apiKey
            config.AddApiKey("X-API-Key", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("X-API-Key", "Bearer");

            var apiInstance = new OptimizationApi(config);
            var optimizeRequest = new OptimizeRequest(); // OptimizeRequest | 

            try
            {
                // Submit a cutting optimization job
                OptimizeAccepted result = apiInstance.CreateOptimization(optimizeRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OptimizationApi.CreateOptimization: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreateOptimizationWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Submit a cutting optimization job
    ApiResponse<OptimizeAccepted> response = apiInstance.CreateOptimizationWithHttpInfo(optimizeRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling OptimizationApi.CreateOptimizationWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **optimizeRequest** | [**OptimizeRequest**](OptimizeRequest.md) |  |  |

### Return type

[**OptimizeAccepted**](OptimizeAccepted.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **202** | Job accepted and queued |  -  |
| **400** | Invalid request (malformed JSON, missing fields, validation error) |  -  |
| **401** | Missing or invalid API key |  -  |
| **403** | API key revoked |  -  |
| **422** | Request is valid but infeasible (e.g. part larger than all sheets) |  -  |
| **429** | Rate limit exceeded |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

