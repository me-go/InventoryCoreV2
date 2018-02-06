# InventoryCoreV2
## https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/complex-data-model
## https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/advanced
## https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/read-related-data
## https://docs.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/intro
## https://docs.microsoft.com/en-us/ef/core/saving/transactions


get-help entityframeworkcore
get-help add-migrations

add-migration init -context InventoryContext
dotnet ef migrations add MaxLengthOnNames

script-migration -context InventoryContext

update-database -context InventoryContext -verbose
dotnet ef database update