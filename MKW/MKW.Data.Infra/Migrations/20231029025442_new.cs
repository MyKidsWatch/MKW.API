using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MKW.Data.Context.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "REPORTED_PERSON_ID",
                table: "TB_RPR_REPORT",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TB_MKW_PLATFORM",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 10, 28, 23, 54, 41, 974, DateTimeKind.Local).AddTicks(4120), new Guid("7ae43548-6a26-49cf-9b63-24fedf7f15ce") });

            migrationBuilder.UpdateData(
                table: "TB_MKW_PLATFORM",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 10, 28, 23, 54, 41, 974, DateTimeKind.Local).AddTicks(4131), new Guid("3e33c08a-2a66-49fc-9cb6-79b24ef11c1e") });

            migrationBuilder.UpdateData(
                table: "TB_MKW_PLATFORM",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 10, 28, 23, 54, 41, 974, DateTimeKind.Local).AddTicks(4133), new Guid("a42d6cd1-e8b4-44cd-bd1e-ada8d770a224") });

            migrationBuilder.UpdateData(
                table: "TB_MKW_PLATFORM_CATEGORY",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 10, 28, 23, 54, 41, 974, DateTimeKind.Local).AddTicks(6513), new Guid("42d90c51-329e-42b5-a150-26d5df4ba73a") });

            migrationBuilder.UpdateData(
                table: "TB_MKW_PLATFORM_CATEGORY",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 10, 28, 23, 54, 41, 974, DateTimeKind.Local).AddTicks(6532), new Guid("8117782c-24ac-4890-9c33-a1422accc853") });

            migrationBuilder.UpdateData(
                table: "TB_MKW_PLATFORM_CATEGORY",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 10, 28, 23, 54, 41, 974, DateTimeKind.Local).AddTicks(6534), new Guid("8455de8d-9c07-4e5c-bb30-1ec3ce5123df") });

            migrationBuilder.UpdateData(
                table: "TB_RPR_REASON",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 10, 28, 23, 54, 41, 975, DateTimeKind.Local).AddTicks(9867), new Guid("420eaa36-f854-417a-bcec-cf7f6235666d") });

            migrationBuilder.UpdateData(
                table: "TB_RPR_REASON",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 10, 28, 23, 54, 41, 975, DateTimeKind.Local).AddTicks(9874), new Guid("09cd561a-27a5-4227-810b-6e9133628f72") });

            migrationBuilder.UpdateData(
                table: "TB_RPR_REASON",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 10, 28, 23, 54, 41, 975, DateTimeKind.Local).AddTicks(9876), new Guid("de8111f2-f000-4d73-9281-e6f8bcfa658c") });

            migrationBuilder.UpdateData(
                table: "TB_RPR_REASON",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 10, 28, 23, 54, 41, 975, DateTimeKind.Local).AddTicks(9878), new Guid("bd229e03-ce76-41a5-8085-a0bbcf17f48d") });

            migrationBuilder.UpdateData(
                table: "TB_RPR_STATUS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 10, 28, 23, 54, 41, 976, DateTimeKind.Local).AddTicks(1649), new Guid("cea9bacd-3de0-4e6a-8d3b-2e85a7a9cc05") });

            migrationBuilder.UpdateData(
                table: "TB_RPR_STATUS",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 10, 28, 23, 54, 41, 976, DateTimeKind.Local).AddTicks(1653), new Guid("0d8c5b54-cfff-4029-b337-1281774a990c") });

            migrationBuilder.UpdateData(
                table: "TB_RPR_STATUS",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 10, 28, 23, 54, 41, 976, DateTimeKind.Local).AddTicks(1665), new Guid("0f0ffaa8-8e83-4361-9baa-19be92ffd869") });

            migrationBuilder.UpdateData(
                table: "TB_USR_GENDER",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ALTER_DATE", "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 10, 28, 23, 54, 41, 969, DateTimeKind.Local).AddTicks(7113), new DateTime(2023, 10, 28, 23, 54, 41, 969, DateTimeKind.Local).AddTicks(7104), new Guid("ad6306b7-35e6-49c2-aee0-70faa08e581c") });

            migrationBuilder.UpdateData(
                table: "TB_USR_GENDER",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "ALTER_DATE", "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 10, 28, 23, 54, 41, 969, DateTimeKind.Local).AddTicks(7127), new DateTime(2023, 10, 28, 23, 54, 41, 969, DateTimeKind.Local).AddTicks(7125), new Guid("2b5180f6-81ce-4f77-929c-98afdc41f809") });

            migrationBuilder.UpdateData(
                table: "TB_USR_GENDER",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "ALTER_DATE", "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 10, 28, 23, 54, 41, 969, DateTimeKind.Local).AddTicks(7130), new DateTime(2023, 10, 28, 23, 54, 41, 969, DateTimeKind.Local).AddTicks(7129), new Guid("c982587b-ed02-43f7-b89a-0153206e3247") });

            migrationBuilder.UpdateData(
                table: "TB_USR_ROLES",
                keyColumn: "Id",
                keyValue: 11111,
                column: "ConcurrencyStamp",
                value: "a812344c-d578-4be2-a332-494adb103d64");

            migrationBuilder.UpdateData(
                table: "TB_USR_ROLES",
                keyColumn: "Id",
                keyValue: 11112,
                column: "ConcurrencyStamp",
                value: "545669fa-27c2-466e-9c93-bdda81ca0e39");

            migrationBuilder.UpdateData(
                table: "TB_USR_USERS",
                keyColumn: "Id",
                keyValue: 11111,
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9094b6c-52db-4b67-979c-8e30ca9ab440", new DateTime(2023, 10, 28, 23, 54, 41, 959, DateTimeKind.Local).AddTicks(2624), "AQAAAAEAACcQAAAAEFeHMBELOo+9FR13dNLfQwDu7i6UsHQODC7vBYrgxkIZU6tsnl0iN2UbsZgRb/E26w==", "d535407c-2d40-430a-83f7-52d1fbf0b193" });

            migrationBuilder.CreateIndex(
                name: "IX_TB_RPR_REPORT_REPORTED_PERSON_ID",
                table: "TB_RPR_REPORT",
                column: "REPORTED_PERSON_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_RPR_REPORT_TB_USR_PERSON_REPORTED_PERSON_ID",
                table: "TB_RPR_REPORT",
                column: "REPORTED_PERSON_ID",
                principalTable: "TB_USR_PERSON",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_RPR_REPORT_TB_USR_PERSON_REPORTED_PERSON_ID",
                table: "TB_RPR_REPORT");

            migrationBuilder.DropIndex(
                name: "IX_TB_RPR_REPORT_REPORTED_PERSON_ID",
                table: "TB_RPR_REPORT");

            migrationBuilder.DropColumn(
                name: "REPORTED_PERSON_ID",
                table: "TB_RPR_REPORT");

            migrationBuilder.UpdateData(
                table: "TB_MKW_PLATFORM",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 10, 4, 18, 38, 52, 360, DateTimeKind.Local).AddTicks(4514), new Guid("deb123ba-6f03-459f-b3ae-120ccc2c51cc") });

            migrationBuilder.UpdateData(
                table: "TB_MKW_PLATFORM",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 10, 4, 18, 38, 52, 360, DateTimeKind.Local).AddTicks(4519), new Guid("704de8e5-3a39-4510-86e3-5b517d2fd1fc") });

            migrationBuilder.UpdateData(
                table: "TB_MKW_PLATFORM",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 10, 4, 18, 38, 52, 360, DateTimeKind.Local).AddTicks(4529), new Guid("1da02678-c633-4177-890d-8086534694f9") });

            migrationBuilder.UpdateData(
                table: "TB_MKW_PLATFORM_CATEGORY",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 10, 4, 18, 38, 52, 360, DateTimeKind.Local).AddTicks(6241), new Guid("856def35-dc43-48b7-9add-9311ab164a15") });

            migrationBuilder.UpdateData(
                table: "TB_MKW_PLATFORM_CATEGORY",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 10, 4, 18, 38, 52, 360, DateTimeKind.Local).AddTicks(6251), new Guid("0a32fd7f-2436-46d4-95e7-290f612ddcb0") });

            migrationBuilder.UpdateData(
                table: "TB_MKW_PLATFORM_CATEGORY",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 10, 4, 18, 38, 52, 360, DateTimeKind.Local).AddTicks(6253), new Guid("903e28a0-f37f-494f-b06c-d8d1d53dc7b4") });

            migrationBuilder.UpdateData(
                table: "TB_RPR_REASON",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 10, 4, 18, 38, 52, 361, DateTimeKind.Local).AddTicks(5506), new Guid("5cfdf859-e25a-4b57-ac97-c43786813fb3") });

            migrationBuilder.UpdateData(
                table: "TB_RPR_REASON",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 10, 4, 18, 38, 52, 361, DateTimeKind.Local).AddTicks(5511), new Guid("342391e9-4fb4-476b-b5bb-a3eb70e1c101") });

            migrationBuilder.UpdateData(
                table: "TB_RPR_REASON",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 10, 4, 18, 38, 52, 361, DateTimeKind.Local).AddTicks(5513), new Guid("2b6ecc27-9a27-4b9b-90ca-6afc482ce518") });

            migrationBuilder.UpdateData(
                table: "TB_RPR_REASON",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 10, 4, 18, 38, 52, 361, DateTimeKind.Local).AddTicks(5515), new Guid("6ef25a99-ffc7-4024-b330-507ec23dc4ee") });

            migrationBuilder.UpdateData(
                table: "TB_RPR_STATUS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 10, 4, 18, 38, 52, 361, DateTimeKind.Local).AddTicks(6787), new Guid("92dee59e-b75c-4b69-ace4-c4fecfcc723b") });

            migrationBuilder.UpdateData(
                table: "TB_RPR_STATUS",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 10, 4, 18, 38, 52, 361, DateTimeKind.Local).AddTicks(6791), new Guid("f8cc3fe7-d6b7-4eb7-955c-d0eae168c559") });

            migrationBuilder.UpdateData(
                table: "TB_RPR_STATUS",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 10, 4, 18, 38, 52, 361, DateTimeKind.Local).AddTicks(6794), new Guid("d6f3dd38-eadc-421e-a565-1261949b42db") });

            migrationBuilder.UpdateData(
                table: "TB_USR_GENDER",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ALTER_DATE", "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 10, 4, 18, 38, 52, 358, DateTimeKind.Local).AddTicks(8739), new DateTime(2023, 10, 4, 18, 38, 52, 358, DateTimeKind.Local).AddTicks(8736), new Guid("db19ca43-dcca-4e17-8168-229fe5c140b4") });

            migrationBuilder.UpdateData(
                table: "TB_USR_GENDER",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "ALTER_DATE", "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 10, 4, 18, 38, 52, 358, DateTimeKind.Local).AddTicks(8760), new DateTime(2023, 10, 4, 18, 38, 52, 358, DateTimeKind.Local).AddTicks(8759), new Guid("bb653181-9caa-4638-b5f3-aa85d3ac61f7") });

            migrationBuilder.UpdateData(
                table: "TB_USR_GENDER",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "ALTER_DATE", "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 10, 4, 18, 38, 52, 358, DateTimeKind.Local).AddTicks(8762), new DateTime(2023, 10, 4, 18, 38, 52, 358, DateTimeKind.Local).AddTicks(8762), new Guid("0446622e-2074-4e55-94a4-cb5898effb23") });

            migrationBuilder.UpdateData(
                table: "TB_USR_ROLES",
                keyColumn: "Id",
                keyValue: 11111,
                column: "ConcurrencyStamp",
                value: "0eb384ad-84c2-4f79-9627-3811ee475043");

            migrationBuilder.UpdateData(
                table: "TB_USR_ROLES",
                keyColumn: "Id",
                keyValue: 11112,
                column: "ConcurrencyStamp",
                value: "aecb8ed1-331b-4fd6-8b93-3b3ddd37a55e");

            migrationBuilder.UpdateData(
                table: "TB_USR_USERS",
                keyColumn: "Id",
                keyValue: 11111,
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "33fb90be-9a32-4482-83ad-a89e221a7fca", new DateTime(2023, 10, 4, 18, 38, 52, 350, DateTimeKind.Local).AddTicks(1642), "AQAAAAEAACcQAAAAEG/S7DGT8O1G/IfnhIw3fnQADTan+vVg9p0aOMyrms83IAUlav/XRNAhspGQPyOlMg==", "db3cb584-8182-40a4-968a-bed3b23e3313" });
        }
    }
}
