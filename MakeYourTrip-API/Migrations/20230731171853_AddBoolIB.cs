using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakeYourTrip_API.Migrations
{
    /// <inheritdoc />
    public partial class AddBoolIB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isBooking",
                table: "PackageBookings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isBooking",
                table: "PackageBookings");
        }
    }
}
