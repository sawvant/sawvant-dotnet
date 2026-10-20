# Sawvant.Api.OptimizationApi

All URIs are relative to *https://api.sawvant.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateBatchOptimization**](OptimizationApi.md#createbatchoptimization) | **POST** /v1/optimize/batch | Submit multiple cutting optimization jobs |
| [**CreateOptimization**](OptimizationApi.md#createoptimization) | **POST** /v1/optimize | Submit a cutting optimization job |

<a id="createbatchoptimization"></a>
# **CreateBatchOptimization**
> BatchAccepted CreateBatchOptimization (BatchRequest batchRequest)

Submit multiple cutting optimization jobs

Enqueues an array of optimization requests as individual jobs and returns their IDs immediately. Poll or stream each job separately.  Maximum 50 fast jobs or 10 thorough jobs per batch. Requires a tier with the `batch` feature. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Sawvant.Api;
using Sawvant.Client;
using Sawvant.Model;

namespace Example
{
    public class CreateBatchOptimizationExample
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
            var batchRequest = new BatchRequest(); // BatchRequest | 

            try
            {
                // Submit multiple cutting optimization jobs
                BatchAccepted result = apiInstance.CreateBatchOptimization(batchRequest);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling OptimizationApi.CreateBatchOptimization: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreateBatchOptimizationWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Submit multiple cutting optimization jobs
    ApiResponse<BatchAccepted> response = apiInstance.CreateBatchOptimizationWithHttpInfo(batchRequest);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling OptimizationApi.CreateBatchOptimizationWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **batchRequest** | [**BatchRequest**](BatchRequest.md) |  |  |

### Return type

[**BatchAccepted**](BatchAccepted.md)

### Authorization

[apiKey](../README.md#apiKey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **202** | Batch accepted; jobs queued |  -  |
| **400** | Invalid request (malformed JSON, empty batch, batch too large) |  -  |
| **401** | Missing or invalid API key |  -  |
| **403** | Tier does not include batch optimization |  -  |
| **429** | Rate limit exceeded |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

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
| **400** | Invalid request. &#x60;error.code&#x60; says what is wrong: &#x60;INVALID_BODY&#x60;, &#x60;BODY_TOO_LARGE&#x60;, &#x60;INVALID_JSON&#x60;, &#x60;INVALID_STRATEGY&#x60;, &#x60;PARTS_EMPTY&#x60;, &#x60;SHEETS_EMPTY&#x60;, &#x60;TOO_MANY_PARTS&#x60;, &#x60;TOO_MANY_SHEETS&#x60; or &#x60;VALIDATION_FAILED&#x60;. For &#x60;INVALID_JSON&#x60; and &#x60;VALIDATION_FAILED&#x60;, &#x60;error.details&#x60; names the offending field.  |  -  |
| **401** | Missing or invalid API key |  -  |
| **403** | API key revoked |  -  |
| **422** | Request is valid but infeasible (&#x60;INFEASIBLE&#x60;): one or more parts do not fit on any sheet. &#x60;error.details&#x60; has one entry per part.  |  -  |
| **500** | Internal error (&#x60;INTERNAL_ERROR&#x60;) |  -  |
| **503** | Rate limiting is temporarily unavailable (&#x60;SERVICE_UNAVAILABLE&#x60;) |  -  |
| **429** | Rate limit exceeded |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

