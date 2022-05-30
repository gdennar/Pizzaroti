using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizzaroti.Migrations
{
    public partial class CorrectedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PizzaImage",
                table: "PizzaOrders");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Transactions",
                newName: "PizzaPrice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PizzaPrice",
                table: "Transactions",
                newName: "Amount");

            migrationBuilder.AddColumn<string>(
                name: "PizzaImage",
                table: "PizzaOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
