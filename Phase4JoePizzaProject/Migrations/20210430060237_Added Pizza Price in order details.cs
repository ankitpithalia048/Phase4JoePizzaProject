using Microsoft.EntityFrameworkCore.Migrations;

namespace Phase4JoePizzaProject.Migrations
{
    public partial class AddedPizzaPriceinorderdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_PizzaModel_PriceID",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_PriceID",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "PriceID",
                table: "OrderDetails");

            migrationBuilder.AddColumn<string>(
                name: "Pizza_PriceID",
                table: "OrderDetails",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Price",
                table: "OrderDetails",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_Pizza_PriceID",
                table: "OrderDetails",
                column: "Pizza_PriceID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_PizzaModel_Pizza_PriceID",
                table: "OrderDetails",
                column: "Pizza_PriceID",
                principalTable: "PizzaModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_PizzaModel_Pizza_PriceID",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_Pizza_PriceID",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Pizza_PriceID",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "OrderDetails");

            migrationBuilder.AddColumn<string>(
                name: "PriceID",
                table: "OrderDetails",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_PriceID",
                table: "OrderDetails",
                column: "PriceID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_PizzaModel_PriceID",
                table: "OrderDetails",
                column: "PriceID",
                principalTable: "PizzaModel",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
