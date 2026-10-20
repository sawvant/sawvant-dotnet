# Sawvant.Model.BatchAccepted

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**BatchId** | **Guid** |  | 
**JobIds** | **List&lt;Guid&gt;** |  | 
**Total** | **int** | Number of jobs in the request | 
**Created** | **int** | Number of jobs successfully enqueued | 
**Results** | [**List&lt;BatchJobResult&gt;**](BatchJobResult.md) | Present only when one or more jobs failed to enqueue | [optional] 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

