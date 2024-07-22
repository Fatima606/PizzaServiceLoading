using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaServiceLoading.Migrations
{
    public partial class updated_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizza_Toppings_ToppingsToppingId",
                table: "Pizza");

            migrationBuilder.DropIndex(
                name: "IX_Pizza_ToppingsToppingId",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "ToppingsToppingId",
                table: "Pizza");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ToppingsToppingId",
                table: "Pizza",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_ToppingsToppingId",
                table: "Pizza",
                column: "ToppingsToppingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Toppings_ToppingsToppingId",
                table: "Pizza",
                column: "ToppingsToppingId",
                principalTable: "Toppings",
                principalColumn: "ToppingId");
        }
    }
}
