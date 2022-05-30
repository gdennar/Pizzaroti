using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizzaroti.Migrations
{
    public partial class CorrectedTransactionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BasePrice",
                table: "PizzaOrders",
                newName: "PizzaPrice");

            migrationBuilder.AddColumn<string>(
                name: "PizzaImage",
                table: "PizzaOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PizzaImage",
                table: "PizzaOrders");

            migrationBuilder.RenameColumn(
                name: "PizzaPrice",
                table: "PizzaOrders",
                newName: "BasePrice");
        }
    }
}
