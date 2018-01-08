using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace InventoryCoreVisualStudio.Migrations
{
    public partial class updateItemAndPartModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WeightUnioofMeasure",
                table: "Item",
                newName: "WeightUnitOfMeasure");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WeightUnitOfMeasure",
                table: "Item",
                newName: "WeightUnioofMeasure");
        }
    }
}
