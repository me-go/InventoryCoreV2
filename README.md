# InventoryCoreV2
## https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro
## https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/sort-filter-page  
## https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/sort-filter-page#add-paging-functionality-to-the-students-index-page

add-migration init -context InventoryContext
get-help entityframeworkcore
get-help add-migrations

script-migration -context InventoryContext

update-database -context InventoryContext -verbose