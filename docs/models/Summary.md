# Sawvant.Model.Summary

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**TotalSheets** | **int** |  | 
**YieldPercent** | **double** |  | 
**WastePercent** | **double** |  | 
**WasteArea** | **double** | mm² | 
**SheetsUsed** | [**List&lt;SheetUsage&gt;**](SheetUsage.md) |  | 
**UnplacedParts** | **List&lt;string&gt;** | IDs of parts the solver could not fit on any available sheet. A grain direction that forbids the only orientation that would fit is a common cause, alongside sheet quantity limits. The rest of the plan is still valid and cuttable. | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

