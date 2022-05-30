using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizzaroti.Migrations
{
    public partial class ChangedBasePriceToPizzaPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PizzaPrice",
                table: "PizzaModel");

            migrationBuilder.RenameColumn(
                name: "BasePrice",
                table: "PizzaOrders",
                newName: "PizzaPrice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PizzaPrice",
                table: "PizzaOrders",
                newName: "BasePrice");

            migrationBuilder.AddColumn<float>(
                name: "PizzaPrice",
                table: "PizzaModel",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
