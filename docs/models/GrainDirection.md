# Sawvant.Model.GrainDirection
Which axis the grain runs along. On a part it is relative to the part's own length and width; on a sheet it is relative to the sheet's. A part may only be placed so that its grain ends up parallel to the sheet's. A sheet that omits the field is treated as having its grain along its length, so `length` and `width` on a part constrain rotation even when the sheet says nothing. Use `none` on the part for material without a grain, or `free_same` to let the solver choose one orientation and apply it to every instance of that part.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------

[[Back to Model list]](../../README.md#documentation-for-models) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to README]](../../README.md)

