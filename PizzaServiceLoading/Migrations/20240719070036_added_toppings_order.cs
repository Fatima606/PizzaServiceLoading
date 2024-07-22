using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaServiceLoading.Migrations
{
    public partial class added_toppings_order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizza_Toppings_ToppingId",
                table: "Pizza");

            migrationBuilder.DropIndex(
                name: "IX_Pizza_ToppingId",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "ToppingId",
                table: "Pizza");

            migrationBuilder.AddColumn<int>(
                name: "ToppingsToppingId",
                table: "Pizza",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ToppingOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaId = table.Column<int>(type: "int", nullable: false),
                    ToppingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToppingOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToppingOrder_Pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizza",
                        principalColumn: "PizzaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToppingOrder_Toppings_ToppingId",
                        column: x => x.ToppingId,
                        principalTable: "Toppings",
                        principalColumn: "ToppingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_ToppingsToppingId",
                table: "Pizza",
                column: "ToppingsToppingId");

            migrationBuilder.CreateIndex(
                name: "IX_ToppingOrder_PizzaId",
                table: "ToppingOrder",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_ToppingOrder_ToppingId",
                table: "ToppingOrder",
                column: "ToppingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Toppings_ToppingsToppingId",
                table: "Pizza",
                column: "ToppingsToppingId",
                principalTable: "Toppings",
                principalColumn: "ToppingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizza_Toppings_ToppingsToppingId",
                table: "Pizza");

            migrationBuilder.DropTable(
                name: "ToppingOrder");

            migrationBuilder.DropIndex(
                name: "IX_Pizza_ToppingsToppingId",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "ToppingsToppingId",
                table: "Pizza");

            migrationBuilder.AddColumn<int>(
                name: "ToppingId",
                table: "Pizza",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_ToppingId",
                table: "Pizza",
                column: "ToppingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Toppings_ToppingId",
                table: "Pizza",
                column: "ToppingId",
                principalTable: "Toppings",
                principalColumn: "ToppingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
