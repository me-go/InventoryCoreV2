# InventoryCoreV2
## https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro

add-migration init -context InventoryContext
get-help entityframeworkcore
get-help add-migrations

script-migration -context InventoryContext

update-database -context InventoryContext -verbose