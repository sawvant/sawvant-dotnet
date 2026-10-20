# Sawvant.Api.DemoApi

All URIs are relative to *https://api.sawvant.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateDemoOptimization**](DemoApi.md#createdemooptimization) | **POST** /v1/demo/optimize | Run a small optimization without an API key |

<a id="createdemooptimization"></a>
# **CreateDemoOptimization**
> DemoOptimizeResponse CreateDemoOptimization (OptimizeRequest optimizeRequest)

Run a small optimization without an API key

Public endpoint behind the playground on sawvant.com. No API key or account needed. Runs the fast strategy synchronously and returns the result together with an SVG cutting plan per layout, so there is no job to poll.  Limits: at most 30 part types, a total part quantity of 100, 3 sheet types and a 64 KB request body. `strategy` must be omitted or `fast`; `cost_tariffs` is ignored. Each client IP may make 10 requests per minute and 100 per day. The input is not stored.  Browsers may only call this endpoint from sawvant.com. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Sawvant.Api;
using Sawvant.Client;
using Sawvant.Model;

namespace Example
{
    public class CreateDemoOptimizationExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.sawvant.com";
            var apiInstance = new DemoApi(config);
            var optimizeRequest = new OptimizeRequest(); // OptimizeRequest | 

            try
            {
                // Run a small optimization without an API key
                DemoOptimizeResponse result = apiInstance.CreateDemoOptimization(optimizeRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DemoApi.CreateDemoOptimization: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreateDemoOptimizationWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Run a small optimization without an API key
    ApiResponse<DemoOptimizeResponse> response = apiInstance.CreateDemoOptimizationWithHttpInfo(optimizeRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DemoApi.CreateDemoOptimizationWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **optimizeRequest** | [**OptimizeRequest**](OptimizeRequest.md) |  |  |

### Return type

[**DemoOptimizeResponse**](DemoOptimizeResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Optimization result with an SVG per layout |  -  |
| **400** | Malformed JSON or a field that fails validation |  -  |
| **413** | Request body larger than 64 KB |  -  |
| **422** | Over a demo limit (&#x60;DEMO_LIMIT_EXCEEDED&#x60;) or infeasible input such as a part larger than every sheet (&#x60;INFEASIBLE&#x60;)  |  -  |
| **429** | Too many demo requests from this IP. See &#x60;Retry-After&#x60;. |  * Retry-After - Seconds to wait before retrying <br>  |
| **500** | Unexpected server error (&#x60;INTERNAL_ERROR&#x60;) |  -  |
| **503** | Too many demo runs in progress, or the server was too busy to finish the solve in time (&#x60;DEMO_BUSY&#x60;). Retry after a few seconds. |  * Retry-After - Seconds to wait before retrying <br>  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

