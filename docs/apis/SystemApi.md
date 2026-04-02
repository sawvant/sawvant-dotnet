# Sawvant.Api.SystemApi

All URIs are relative to *https://api.sawvant.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetHealth**](SystemApi.md#gethealth) | **GET** /health | Health check |
| [**ListTiers**](SystemApi.md#listtiers) | **GET** /v1/tiers | List available subscription tiers |

<a id="gethealth"></a>
# **GetHealth**
> HealthResponse GetHealth ()

Health check

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Sawvant.Api;
using Sawvant.Client;
using Sawvant.Model;

namespace Example
{
    public class GetHealthExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.sawvant.com";
            var apiInstance = new SystemApi(config);

            try
            {
                // Health check
                HealthResponse result = apiInstance.GetHealth();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SystemApi.GetHealth: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetHealthWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Health check
    ApiResponse<HealthResponse> response = apiInstance.GetHealthWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SystemApi.GetHealthWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**HealthResponse**](HealthResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Service is healthy |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="listtiers"></a>
# **ListTiers**
> List&lt;TierDefinition&gt; ListTiers ()

List available subscription tiers

Returns all available subscription tiers with their rate limits, pricing, and feature gates. This is the single source of truth for tier configuration. 

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Sawvant.Api;
using Sawvant.Client;
using Sawvant.Model;

namespace Example
{
    public class ListTiersExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.sawvant.com";
            var apiInstance = new SystemApi(config);

            try
            {
                // List available subscription tiers
                List<TierDefinition> result = apiInstance.ListTiers();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SystemApi.ListTiers: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ListTiersWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // List available subscription tiers
    ApiResponse<List<TierDefinition>> response = apiInstance.ListTiersWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SystemApi.ListTiersWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**List&lt;TierDefinition&gt;**](TierDefinition.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | List of tier definitions |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

