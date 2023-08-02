using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakeYourTrip_API.Migrations
{
    /// <inheritdoc />
    public partial class AddBillFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gst",
                table: "PackageBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GuideCost",
                table: "PackageBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Hotel",
                table: "PackageBookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HotelCost",
                table: "PackageBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gst",
                table: "PackageBookings");

            migrationBuilder.DropColumn(
                name: "GuideCost",
                table: "PackageBookings");

            migrationBuilder.DropColumn(
                name: "Hotel",
                table: "PackageBookings");

            migrationBuilder.DropColumn(
                name: "HotelCost",
                table: "PackageBookings");
        }
    }
}
