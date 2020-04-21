using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelPlannerServer.Migrations
{
    public partial class UpdatePrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Trips",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Offers",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Trips");

            migrationBuilder.AlterColumn<long>(
                name: "Price",
                table: "Offers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
