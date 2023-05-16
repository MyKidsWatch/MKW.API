using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MKW.Data.Context.Migrations
{
    public partial class CreateInitialIdentityData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 11111, "cd041160-c264-42ba-8ff8-164e920de6a5", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 11112, "4de591c7-8d41-41d7-b797-9c9f74457e8f", "standard", "STANDARD" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Active", "AlterDate", "ConcurrencyStamp", "CreateDate", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 11111, 0, true, null, "84902f9e-2819-40c8-bfca-594e6c88698f", new DateTime(2023, 5, 13, 2, 17, 36, 150, DateTimeKind.Local).AddTicks(8877), "projeto.mkw@gmail.com", true, "Administrador", "MyKidsWatch", false, null, "PROJETO.MWK@GMAIL.COM", "ADMIN11111", "AQAAAAEAACcQAAAAEIp/N0AmtrREQkVM+RK0Kl7Isat5PwwjRah8CTM0fuMOVsbRO+qV+aR1MIUeK8ZJAg==", "5511978019550", true, "b5780c6f-524d-4647-ade5-81af17f264f0", true, "admin11111" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 11111, 11111 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 11112);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 11111, 11111 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 11111);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 11111);
        }
    }
}
