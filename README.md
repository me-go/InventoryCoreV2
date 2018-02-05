# InventoryCoreV2
## https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro
## https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/migrations

get-help entityframeworkcore
get-help add-migrations

add-migration init -context InventoryContext
dotnet ef migrations add MaxLengthOnNames

script-migration -context InventoryContext

update-database -context InventoryContext -verbose
dotnet ef database update