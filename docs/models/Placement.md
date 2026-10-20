# Sawvant.Model.Placement

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**PartId** | **string** |  | 
**SheetId** | **string** | Which sheet type this part is placed on | 
**X** | **double** | mm from the top-left of the usable area, along the sheet&#39;s length axis. x + width never exceeds the usable length. | 
**Y** | **double** | mm from the top-left of the usable area, along the sheet&#39;s width axis. y + height never exceeds the usable width. | 
**Width** | **double** | Post-edge-banding dimension along the sheet&#39;s length axis | 
**Height** | **double** | Post-edge-banding dimension along the sheet&#39;s width axis | 
**Rotated** | **bool** | True when the part&#39;s length runs along the sheet&#39;s width axis, so width is the part&#39;s width and height is its length. | 
**Grain** | **GrainDirection** |  | 

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

