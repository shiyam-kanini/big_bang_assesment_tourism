﻿// <auto-generated />
using System;
using MakeYourTrip_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MakeYourTrip_API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230729175233_ChangeType")]
    partial class ChangeType
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MakeYourTrip_API.Models.Coupon", b =>
                {
                    b.Property<string>("CouponId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ApplicablePackagePackageId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CouponDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CouponExpiration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CouponName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CouponId");

                    b.HasIndex("ApplicablePackagePackageId");

                    b.ToTable("Coupons");
                });

            modelBuilder.Entity("MakeYourTrip_API.Models.Employee", b =>
                {
                    b.Property<string>("EmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeePhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordKey")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Specialization")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("RoleId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("MakeYourTrip_API.Models.Festival", b =>
                {
                    b.Property<string>("FestivalId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FestivalDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FestivalMonth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FestivalName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FestivalId");

                    b.ToTable("Festivals");
                });

            modelBuilder.Entity("MakeYourTrip_API.Models.LoginLog", b =>
                {
                    b.Property<string>("SessionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsLoggedIn")
                        .HasColumnType("bit");

                    b.Property<string>("LoginId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SessionId");

                    b.ToTable("LoginLogs");
                });

            modelBuilder.Entity("MakeYourTrip_API.Models.Package", b =>
                {
                    b.Property<string>("PackageId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PackageDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PackageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PackageType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlaceCount")
                        .HasColumnType("int");

                    b.HasKey("PackageId");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("MakeYourTrip_API.Models.PackageBooking", b =>
                {
                    b.Property<string>("PackageUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BookingDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Coupon_IdCouponId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GuideEmployeeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("JourneyDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JourneyDays")
                        .HasColumnType("int");

                    b.Property<string>("Package_IdPackageId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("User_IdUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PackageUserId");

                    b.HasIndex("Coupon_IdCouponId");

                    b.HasIndex("GuideEmployeeId");

                    b.HasIndex("Package_IdPackageId");

                    b.HasIndex("User_IdUserId");

                    b.ToTable("PackageBookings");
                });

            modelBuilder.Entity("MakeYourTrip_API.Models.Place", b =>
                {
                    b.Property<string>("PlaceId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("AmenityBathroom")
                        .HasColumnType("bit");

                    b.Property<bool>("AmenityParking")
                        .HasColumnType("bit");

                    b.Property<string>("PackageBookingPackageUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PlaceDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlaceRating")
                        .HasColumnType("int");

                    b.Property<string>("PlaceState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PlaceStatus")
                        .HasColumnType("bit");

                    b.Property<string>("PlaceType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VisitingDay")
                        .HasColumnType("int");

                    b.Property<string>("placeCountry")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlaceId");

                    b.HasIndex("PackageBookingPackageUserId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("MakeYourTrip_API.Models.PlaceFestival", b =>
                {
                    b.Property<string>("PlaceFestivalId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FestivalId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PlaceId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PlaceFestivalId");

                    b.HasIndex("FestivalId");

                    b.HasIndex("PlaceId");

                    b.ToTable("PlacesFestivals");
                });

            modelBuilder.Entity("MakeYourTrip_API.Models.PlaceImage", b =>
                {
                    b.Property<string>("PlaceImageId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PlaceImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Place_Id_IPlaceId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PlaceImageId");

                    b.HasIndex("Place_Id_IPlaceId");

                    b.ToTable("PlacesImages");
                });

            modelBuilder.Entity("MakeYourTrip_API.Models.Role", b =>
                {
                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("MakeYourTrip_API.Models.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsActive")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordKey")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MakeYourTrip_API.Models.Coupon", b =>
                {
                    b.HasOne("MakeYourTrip_API.Models.Package", "ApplicablePackage")
                        .WithMany("Coupons")
                        .HasForeignKey("ApplicablePackagePackageId");

                    b.Navigation("ApplicablePackage");
                });

            modelBuilder.Entity("MakeYourTrip_API.Models.Employee", b =>
                {
                    b.HasOne("MakeYourTrip_API.Models.Role", "Role")
                        .WithMany("Employees")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MakeYourTrip_API.Models.PackageBooking", b =>
                {
                    b.HasOne("MakeYourTrip_API.Models.Coupon", "Coupon_Id")
                        .WithMany("Bookings")
                        .HasForeignKey("Coupon_IdCouponId");

                    b.HasOne("MakeYourTrip_API.Models.Employee", "Guide")
                        .WithMany("PackageBooking")
                        .HasForeignKey("GuideEmployeeId");

                    b.HasOne("MakeYourTrip_API.Models.Package", "Package_Id")
                        .WithMany("Bookings")
                        .HasForeignKey("Package_IdPackageId");

                    b.HasOne("MakeYourTrip_API.Models.User", "User_Id")
                        .WithMany("PackageBookings")
                        .HasForeignKey("User_IdUserId");

                    b.Navigation("Coupon_Id");

                    b.Navigation("Guide");

                    b.Navigation("Package_Id");

                    b.Navigation("User_Id");
                });

            modelBuilder.Entity("MakeYourTrip_API.Models.Place", b =>
                {
                    b.HasOne("MakeYourTrip_API.Models.PackageBooking", null)
                        .WithMany("Places_Id")
                        .HasForeignKey("PackageBookingPackageUserId");
                });

            modelBuilder.Entity("MakeYourTrip_API.Models.PlaceFestival", b =>
                {
                    b.HasOne("MakeYourTrip_API.Models.Festival", "Festival")
                        .WithMany()
                        .HasForeignKey("FestivalId");

                    b.HasOne("MakeYourTrip_API.Models.Place", "Place")
                        .WithMany("PlaceFestivals")
                        .HasForeignKey("PlaceId");

                    b.Navigation("Festival");

                    b.Navigation("Place");
                });

            modelBuilder.Entity("MakeYourTrip_API.Models.PlaceImage", b =>
                {
                    b.HasOne("MakeYourTrip_API.Models.Place", "Place_Id_I")
                        .WithMany("PlaceImages")
                        .HasForeignKey("Place_Id_IPlaceId");

                    b.Navigation("Place_Id_I");
                });

            modelBuilder.Entity("MakeYourTrip_API.Models.Coupon", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("MakeYourTrip_API.Models.Employee", b =>
                {
                    b.Navigation("PackageBooking");
                });

            modelBuilder.Entity("MakeYourTrip_API.Models.Package", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Coupons");
                });

            modelBuilder.Entity("MakeYourTrip_API.Models.PackageBooking", b =>
                {
                    b.Navigation("Places_Id");
                });

            modelBuilder.Entity("MakeYourTrip_API.Models.Place", b =>
                {
                    b.Navigation("PlaceFestivals");

                    b.Navigation("PlaceImages");
                });

            modelBuilder.Entity("MakeYourTrip_API.Models.Role", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("MakeYourTrip_API.Models.User", b =>
                {
                    b.Navigation("PackageBookings");
                });
#pragma warning restore 612, 618
        }
    }
}
