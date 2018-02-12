# InventoryCoreV2

## https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro
## https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/migrations
## https://www.youtube.com/watch?v=E7Voso411Vs

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


EF Hierarchy for categories

https://forums.asp.net/t/2052282.aspx?how+to+select+parent+and+children+in+one+select+using+entity+framework+in+a+self+related+table
https://www.mikesdotnetting.com/article/255/entity-framework-recipe-hierarchical-data-management