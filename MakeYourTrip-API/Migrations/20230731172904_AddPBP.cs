using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakeYourTrip_API.Migrations
{
    /// <inheritdoc />
    public partial class AddPBP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PackageBookingsPlaces",
                columns: table => new
                {
                    PBPId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PackageBooking_IdPackageUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Place_PB_IdPlaceId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageBookingsPlaces", x => x.PBPId);
                    table.ForeignKey(
                        name: "FK_PackageBookingsPlaces_PackageBookings_PackageBooking_IdPackageUserId",
                        column: x => x.PackageBooking_IdPackageUserId,
                        principalTable: "PackageBookings",
                        principalColumn: "PackageUserId");
                    table.ForeignKey(
                        name: "FK_PackageBookingsPlaces_Places_Place_PB_IdPlaceId",
                        column: x => x.Place_PB_IdPlaceId,
                        principalTable: "Places",
                        principalColumn: "PlaceId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackageBookingsPlaces_PackageBooking_IdPackageUserId",
                table: "PackageBookingsPlaces",
                column: "PackageBooking_IdPackageUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageBookingsPlaces_Place_PB_IdPlaceId",
                table: "PackageBookingsPlaces",
                column: "Place_PB_IdPlaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackageBookingsPlaces");
        }
    }
}
