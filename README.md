# InventoryCoreV2
## https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro
## https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/sort-filter-page#create-an-about-page-that-shows-student-statistics

add-migration init -context InventoryContext
get-help entityframeworkcore
get-help add-migrations

script-migration -context InventoryContext

update-database -context InventoryContext -verbose