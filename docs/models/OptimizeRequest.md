# Sawvant.Model.OptimizeRequest

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Parts** | [**List&lt;Part&gt;**](Part.md) |  | 
**Sheets** | [**List&lt;Sheet&gt;**](Sheet.md) |  | 
**Machine** | [**Machine**](Machine.md) |  | 
**Strategy** | **string** | Solve strategy. \&quot;fast\&quot; runs all greedy solvers concurrently. \&quot;thorough\&quot; adds Gilmore-Gomory column generation for optimal patterns. Each strategy has its own rate limit quota.  | [optional] [default to StrategyEnum.Fast]
**CostTariffs** | [**CostTariffs**](CostTariffs.md) |  | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

