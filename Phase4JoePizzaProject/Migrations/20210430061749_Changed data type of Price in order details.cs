using Microsoft.EntityFrameworkCore.Migrations;

namespace Phase4JoePizzaProject.Migrations
{
    public partial class ChangeddatatypeofPriceinorderdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "OrderDetails",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Price",
                table: "OrderDetails",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
