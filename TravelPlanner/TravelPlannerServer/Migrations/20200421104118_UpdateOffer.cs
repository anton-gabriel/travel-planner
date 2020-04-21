using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelPlannerServer.Migrations
{
    public partial class UpdateOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "LocationType",
                table: "Offers",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationType",
                table: "Offers");
        }
    }
}
