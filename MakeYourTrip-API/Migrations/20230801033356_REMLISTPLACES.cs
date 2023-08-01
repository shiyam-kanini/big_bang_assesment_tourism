using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakeYourTrip_API.Migrations
{
    /// <inheritdoc />
    public partial class REMLISTPLACES : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_PackageBookings_PackageBookingPackageUserId",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Places_PackageBookingPackageUserId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "PackageBookingPackageUserId",
                table: "Places");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PackageBookingPackageUserId",
                table: "Places",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Places_PackageBookingPackageUserId",
                table: "Places",
                column: "PackageBookingPackageUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_PackageBookings_PackageBookingPackageUserId",
                table: "Places",
                column: "PackageBookingPackageUserId",
                principalTable: "PackageBookings",
                principalColumn: "PackageUserId");
        }
    }
}
