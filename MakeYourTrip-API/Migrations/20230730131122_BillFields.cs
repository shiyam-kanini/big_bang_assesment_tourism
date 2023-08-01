using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakeYourTrip_API.Migrations
{
    /// <inheritdoc />
    public partial class BillFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Married",
                table: "Users",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlacePrice",
                table: "Places",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PackagePrice",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalCost",
                table: "PackageBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CouponDiscountPercentage",
                table: "Coupons",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Married",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PlacePrice",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "PackagePrice",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "PackageBookings");

            migrationBuilder.DropColumn(
                name: "CouponDiscountPercentage",
                table: "Coupons");
        }
    }
}
