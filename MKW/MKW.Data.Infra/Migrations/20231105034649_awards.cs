using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MKW.Data.Context.Migrations
{
    public partial class awards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TB_MKW_PLATFORM",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 46, 49, 272, DateTimeKind.Local).AddTicks(2137), new Guid("874f0c9f-a23b-45a3-99b7-da4eace200bc") });

            migrationBuilder.UpdateData(
                table: "TB_MKW_PLATFORM",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 46, 49, 272, DateTimeKind.Local).AddTicks(2144), new Guid("91952b78-99e8-457c-9771-156111efa2fd") });

            migrationBuilder.UpdateData(
                table: "TB_MKW_PLATFORM",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 46, 49, 272, DateTimeKind.Local).AddTicks(2145), new Guid("bfe2cbe8-6fac-49ed-92af-48b85bd76b0e") });

            migrationBuilder.UpdateData(
                table: "TB_MKW_PLATFORM_CATEGORY",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 46, 49, 272, DateTimeKind.Local).AddTicks(3750), new Guid("2bbe8fd7-9e9f-44db-9aa8-73cefc846e30") });

            migrationBuilder.UpdateData(
                table: "TB_MKW_PLATFORM_CATEGORY",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 46, 49, 272, DateTimeKind.Local).AddTicks(3755), new Guid("af91dc16-69f9-4347-8a47-830ec469ee4e") });

            migrationBuilder.UpdateData(
                table: "TB_MKW_PLATFORM_CATEGORY",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 46, 49, 272, DateTimeKind.Local).AddTicks(3764), new Guid("36a98e0e-ab5f-49b5-837c-58da9e555ba1") });

            migrationBuilder.UpdateData(
                table: "TB_RPR_REASON",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 46, 49, 273, DateTimeKind.Local).AddTicks(3886), new Guid("6a4043fd-f78a-42ec-a1a4-bbcf6bb5e177") });

            migrationBuilder.UpdateData(
                table: "TB_RPR_REASON",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 46, 49, 273, DateTimeKind.Local).AddTicks(3893), new Guid("bfe0acac-cc7e-4899-ab53-b7b34c99ad32") });

            migrationBuilder.UpdateData(
                table: "TB_RPR_REASON",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 46, 49, 273, DateTimeKind.Local).AddTicks(3895), new Guid("9eb4fd08-00d8-4d4d-bbd7-28405e88626e") });

            migrationBuilder.UpdateData(
                table: "TB_RPR_REASON",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 46, 49, 273, DateTimeKind.Local).AddTicks(3896), new Guid("d39047d3-74a0-416d-8c3b-2107cf3a396d") });

            migrationBuilder.UpdateData(
                table: "TB_RPR_STATUS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 46, 49, 273, DateTimeKind.Local).AddTicks(5035), new Guid("137a3b89-b7c4-499a-9e99-297cd8aead59") });

            migrationBuilder.UpdateData(
                table: "TB_RPR_STATUS",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 46, 49, 273, DateTimeKind.Local).AddTicks(5039), new Guid("1c4fe374-c5df-44e1-aaaa-b39b4a5a7b99") });

            migrationBuilder.UpdateData(
                table: "TB_RPR_STATUS",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 46, 49, 273, DateTimeKind.Local).AddTicks(5041), new Guid("7a58e127-a361-4ebc-bf77-5f2319e360ee") });

            migrationBuilder.UpdateData(
                table: "TB_RVW_AWARD",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 46, 49, 266, DateTimeKind.Local).AddTicks(7502), new Guid("2b17391f-4269-4ad0-a1bd-a277e75ab599") });

            migrationBuilder.UpdateData(
                table: "TB_RVW_AWARD",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 46, 49, 266, DateTimeKind.Local).AddTicks(7507), new Guid("f54a4429-fa14-4102-8011-bb2f587b274a") });

            migrationBuilder.UpdateData(
                table: "TB_RVW_AWARD",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 46, 49, 266, DateTimeKind.Local).AddTicks(7509), new Guid("db0e591c-717f-43fe-8123-1fda7f4a5eba") });

            migrationBuilder.UpdateData(
                table: "TB_USR_GENDER",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ALTER_DATE", "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 46, 49, 268, DateTimeKind.Local).AddTicks(5381), new DateTime(2023, 11, 5, 0, 46, 49, 268, DateTimeKind.Local).AddTicks(5377), new Guid("1cbed195-d152-4014-b9e7-a90332dbed36") });

            migrationBuilder.UpdateData(
                table: "TB_USR_GENDER",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "ALTER_DATE", "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 46, 49, 268, DateTimeKind.Local).AddTicks(5385), new DateTime(2023, 11, 5, 0, 46, 49, 268, DateTimeKind.Local).AddTicks(5385), new Guid("e7fa63d2-c2ba-4a4f-89bd-569881cbe546") });

            migrationBuilder.UpdateData(
                table: "TB_USR_GENDER",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "ALTER_DATE", "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 46, 49, 268, DateTimeKind.Local).AddTicks(5387), new DateTime(2023, 11, 5, 0, 46, 49, 268, DateTimeKind.Local).AddTicks(5386), new Guid("37679dbc-10e9-40cc-bc76-158bb0ec89fb") });

            migrationBuilder.UpdateData(
                table: "TB_USR_ROLES",
                keyColumn: "Id",
                keyValue: 11111,
                column: "ConcurrencyStamp",
                value: "504566fc-c361-4bef-bcd8-b321dd7a7948");

            migrationBuilder.UpdateData(
                table: "TB_USR_ROLES",
                keyColumn: "Id",
                keyValue: 11112,
                column: "ConcurrencyStamp",
                value: "3b3ff28d-4dc5-446e-9491-c84beffd75cf");

            migrationBuilder.UpdateData(
                table: "TB_USR_USERS",
                keyColumn: "Id",
                keyValue: 11111,
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f61da656-d466-43ed-809b-74707f8d43d9", new DateTime(2023, 11, 5, 0, 46, 49, 260, DateTimeKind.Local).AddTicks(1013), "AQAAAAEAACcQAAAAEE2dn74Lm9Ixgt03bcHLegJfi1pwtWfGCQvq4O+dWQIcfjQvPiKY6Ehn7XuhpHfbYA==", "3e0ecc3d-aed6-4262-921e-a90e4744b05c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TB_MKW_PLATFORM",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 45, 22, 823, DateTimeKind.Local).AddTicks(1507), new Guid("a0a6d5b9-d478-4cd0-b0c0-99e1f2f00f97") });

            migrationBuilder.UpdateData(
                table: "TB_MKW_PLATFORM",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 45, 22, 823, DateTimeKind.Local).AddTicks(1513), new Guid("ef09e8b0-7687-4b01-9efe-82a5a9aeb19e") });

            migrationBuilder.UpdateData(
                table: "TB_MKW_PLATFORM",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 45, 22, 823, DateTimeKind.Local).AddTicks(1522), new Guid("6f5d389f-bd30-440a-a75f-bcc9eb734782") });

            migrationBuilder.UpdateData(
                table: "TB_MKW_PLATFORM_CATEGORY",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 45, 22, 823, DateTimeKind.Local).AddTicks(3459), new Guid("d9369258-71b8-4454-b7f0-b6d4a805d815") });

            migrationBuilder.UpdateData(
                table: "TB_MKW_PLATFORM_CATEGORY",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 45, 22, 823, DateTimeKind.Local).AddTicks(3464), new Guid("929bb579-bd52-4189-a235-83529f0eb806") });

            migrationBuilder.UpdateData(
                table: "TB_MKW_PLATFORM_CATEGORY",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 45, 22, 823, DateTimeKind.Local).AddTicks(3466), new Guid("0f410356-b76b-4deb-b3a9-26c5dde933a5") });

            migrationBuilder.UpdateData(
                table: "TB_RPR_REASON",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 45, 22, 824, DateTimeKind.Local).AddTicks(4887), new Guid("053af215-920f-4d65-83cb-5674d46973af") });

            migrationBuilder.UpdateData(
                table: "TB_RPR_REASON",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 45, 22, 824, DateTimeKind.Local).AddTicks(4892), new Guid("2ffc0665-96f9-49f8-befb-f3a902b8b1eb") });

            migrationBuilder.UpdateData(
                table: "TB_RPR_REASON",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 45, 22, 824, DateTimeKind.Local).AddTicks(4894), new Guid("b08e652b-8b02-4077-a0c8-10a2b130c8da") });

            migrationBuilder.UpdateData(
                table: "TB_RPR_REASON",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 45, 22, 824, DateTimeKind.Local).AddTicks(4896), new Guid("0d1eeed3-8b0f-4375-85b7-277460247cab") });

            migrationBuilder.UpdateData(
                table: "TB_RPR_STATUS",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 45, 22, 824, DateTimeKind.Local).AddTicks(6418), new Guid("ece561cd-cfb9-4bd5-bda0-2f4b515ba41f") });

            migrationBuilder.UpdateData(
                table: "TB_RPR_STATUS",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 45, 22, 824, DateTimeKind.Local).AddTicks(6424), new Guid("e5e66a89-6387-4077-9939-916963cf515f") });

            migrationBuilder.UpdateData(
                table: "TB_RPR_STATUS",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 45, 22, 824, DateTimeKind.Local).AddTicks(6425), new Guid("48d5ca65-e349-4b07-938d-f9a12c23d69f") });

            migrationBuilder.UpdateData(
                table: "TB_RVW_AWARD",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 45, 22, 816, DateTimeKind.Local).AddTicks(7589), new Guid("ed1777fd-49bf-4aa2-8438-4d443f2f3a5e") });

            migrationBuilder.UpdateData(
                table: "TB_RVW_AWARD",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 45, 22, 816, DateTimeKind.Local).AddTicks(7596), new Guid("79a94cc6-e90e-4bbe-bf4a-4811289f3aa2") });

            migrationBuilder.UpdateData(
                table: "TB_RVW_AWARD",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 45, 22, 816, DateTimeKind.Local).AddTicks(7599), new Guid("d5c232ad-a514-4f80-9ce9-a0c1b202a457") });

            migrationBuilder.UpdateData(
                table: "TB_USR_GENDER",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ALTER_DATE", "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 45, 22, 819, DateTimeKind.Local).AddTicks(1492), new DateTime(2023, 11, 5, 0, 45, 22, 819, DateTimeKind.Local).AddTicks(1488), new Guid("82b0e3d8-2223-477c-ab5c-fa0aba22641b") });

            migrationBuilder.UpdateData(
                table: "TB_USR_GENDER",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "ALTER_DATE", "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 45, 22, 819, DateTimeKind.Local).AddTicks(1496), new DateTime(2023, 11, 5, 0, 45, 22, 819, DateTimeKind.Local).AddTicks(1495), new Guid("c5ce8239-3140-44e3-90c0-2cae8881ead7") });

            migrationBuilder.UpdateData(
                table: "TB_USR_GENDER",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "ALTER_DATE", "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 11, 5, 0, 45, 22, 819, DateTimeKind.Local).AddTicks(1498), new DateTime(2023, 11, 5, 0, 45, 22, 819, DateTimeKind.Local).AddTicks(1497), new Guid("c514f6da-bc2b-4304-9799-4357503c9f11") });

            migrationBuilder.UpdateData(
                table: "TB_USR_ROLES",
                keyColumn: "Id",
                keyValue: 11111,
                column: "ConcurrencyStamp",
                value: "51dbbd22-c9bd-420d-aa49-e1f07995d30d");

            migrationBuilder.UpdateData(
                table: "TB_USR_ROLES",
                keyColumn: "Id",
                keyValue: 11112,
                column: "ConcurrencyStamp",
                value: "4666dfa0-964c-4944-ace1-ebd8283247a8");

            migrationBuilder.UpdateData(
                table: "TB_USR_USERS",
                keyColumn: "Id",
                keyValue: 11111,
                columns: new[] { "ConcurrencyStamp", "CreateDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5efd657a-e0a8-4e51-8232-a66b76452d9e", new DateTime(2023, 11, 5, 0, 45, 22, 809, DateTimeKind.Local).AddTicks(6933), "AQAAAAEAACcQAAAAEPd+rpjgOyyL284Jbn7dzSxjezpBOVrHTv9waoqr1byZG8otLoN1GzAVEW0EgakpTA==", "a0f22fd3-50cf-420e-8c4d-a6d01961a054" });
        }
    }
}
