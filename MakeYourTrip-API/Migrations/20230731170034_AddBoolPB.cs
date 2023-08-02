using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakeYourTrip_API.Migrations
{
    /// <inheritdoc />
    public partial class AddBoolPB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Married",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PackageImgURL",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isBooked",
                table: "PackageBookings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PackageImgURL",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "isBooked",
                table: "PackageBookings");

            migrationBuilder.AlterColumn<bool>(
                name: "Married",
                table: "Users",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
