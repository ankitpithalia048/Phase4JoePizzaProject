using Microsoft.EntityFrameworkCore.Migrations;

namespace Phase4JoePizzaProject.Migrations
{
    public partial class AddedPriceinorderdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PriceID",
                table: "OrderDetails",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
