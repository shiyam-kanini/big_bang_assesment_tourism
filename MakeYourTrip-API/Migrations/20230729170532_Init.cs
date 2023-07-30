using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MakeYourTrip_API.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Festivals",
                columns: table => new
                {
                    FestivalId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FestivalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FestivalDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FestivalMonth = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Festivals", x => x.FestivalId);
                });

            migrationBuilder.CreateTable(
                name: "LoginLogs",
                columns: table => new
                {
                    SessionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLoggedIn = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginLogs", x => x.SessionId);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    PackageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PackageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.PackageId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordKey = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UserState = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    CouponId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CouponName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CouponDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CouponExpiration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicablePackagePackageId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.CouponId);
                    table.ForeignKey(
                        name: "FK_Coupons_Packages_ApplicablePackagePackageId",
                        column: x => x.ApplicablePackagePackageId,
                        principalTable: "Packages",
                        principalColumn: "PackageId");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordKey = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EmployeeState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId");
                });

            migrationBuilder.CreateTable(
                name: "PackageBookings",
                columns: table => new
                {
                    PackageUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    User_IdUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Package_IdPackageId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Coupon_IdCouponId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    GuideEmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BookingDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JourneyDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JourneyDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageBookings", x => x.PackageUserId);
                    table.ForeignKey(
                        name: "FK_PackageBookings_Coupons_Coupon_IdCouponId",
                        column: x => x.Coupon_IdCouponId,
                        principalTable: "Coupons",
                        principalColumn: "CouponId");
                    table.ForeignKey(
                        name: "FK_PackageBookings_Employees_GuideEmployeeId",
                        column: x => x.GuideEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_PackageBookings_Packages_Package_IdPackageId",
                        column: x => x.Package_IdPackageId,
                        principalTable: "Packages",
                        principalColumn: "PackageId");
                    table.ForeignKey(
                        name: "FK_PackageBookings_Users_User_IdUserId",
                        column: x => x.User_IdUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    PlaceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlaceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    placeCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceStatus = table.Column<bool>(type: "bit", nullable: false),
                    PlaceUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceRating = table.Column<int>(type: "int", nullable: true),
                    AmenityParking = table.Column<bool>(type: "bit", nullable: false),
                    AmenityBathroom = table.Column<bool>(type: "bit", nullable: false),
                    VisitingDay = table.Column<int>(type: "int", nullable: false),
                    PackageBookingPackageUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.PlaceId);
                    table.ForeignKey(
                        name: "FK_Places_PackageBookings_PackageBookingPackageUserId",
                        column: x => x.PackageBookingPackageUserId,
                        principalTable: "PackageBookings",
                        principalColumn: "PackageUserId");
                });

            migrationBuilder.CreateTable(
                name: "PlacesFestivals",
                columns: table => new
                {
                    PlaceFestivalId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlaceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FestivalId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacesFestivals", x => x.PlaceFestivalId);
                    table.ForeignKey(
                        name: "FK_PlacesFestivals_Festivals_FestivalId",
                        column: x => x.FestivalId,
                        principalTable: "Festivals",
                        principalColumn: "FestivalId");
                    table.ForeignKey(
                        name: "FK_PlacesFestivals_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "PlaceId");
                });

            migrationBuilder.CreateTable(
                name: "PlacesImages",
                columns: table => new
                {
                    PlaceImageId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Place_Id_IPlaceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PlaceImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacesImages", x => x.PlaceImageId);
                    table.ForeignKey(
                        name: "FK_PlacesImages_Places_Place_Id_IPlaceId",
                        column: x => x.Place_Id_IPlaceId,
                        principalTable: "Places",
                        principalColumn: "PlaceId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_ApplicablePackagePackageId",
                table: "Coupons",
                column: "ApplicablePackagePackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleId",
                table: "Employees",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageBookings_Coupon_IdCouponId",
                table: "PackageBookings",
                column: "Coupon_IdCouponId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageBookings_GuideEmployeeId",
                table: "PackageBookings",
                column: "GuideEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageBookings_Package_IdPackageId",
                table: "PackageBookings",
                column: "Package_IdPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageBookings_User_IdUserId",
                table: "PackageBookings",
                column: "User_IdUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_PackageBookingPackageUserId",
                table: "Places",
                column: "PackageBookingPackageUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacesFestivals_FestivalId",
                table: "PlacesFestivals",
                column: "FestivalId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacesFestivals_PlaceId",
                table: "PlacesFestivals",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacesImages_Place_Id_IPlaceId",
                table: "PlacesImages",
                column: "Place_Id_IPlaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginLogs");

            migrationBuilder.DropTable(
                name: "PlacesFestivals");

            migrationBuilder.DropTable(
                name: "PlacesImages");

            migrationBuilder.DropTable(
                name: "Festivals");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropTable(
                name: "PackageBookings");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
