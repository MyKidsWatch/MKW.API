using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MKW.Data.Context.Migrations
{
    public partial class newEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_USR_PERSON_TB_USR_USERS_USER_ID",
                table: "TB_USR_PERSON");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_USR_ROLE_CLAIM_TB_USR_ROLES_RoleId",
                table: "TB_USR_ROLE_CLAIM");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_USR_USER_CLAIM_TB_USR_USERS_UserId",
                table: "TB_USR_USER_CLAIM");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_USR_USER_KEYCODE_TB_USR_USERS_USER_ID",
                table: "TB_USR_USER_KEYCODE");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_USR_USER_LOGIN_TB_USR_USERS_UserId",
                table: "TB_USR_USER_LOGIN");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_USR_USER_ROLE_TB_USR_ROLES_RoleId",
                table: "TB_USR_USER_ROLE");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_USR_USER_ROLE_TB_USR_USERS_UserId",
                table: "TB_USR_USER_ROLE");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_USR_USER_TOKEN_TB_USR_USERS_UserId",
                table: "TB_USR_USER_TOKEN");

            migrationBuilder.DropTable(
                name: "TB_USR_TRANSACTION");

            migrationBuilder.DropTable(
                name: "TB_USR_BALANCE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_USR_USERS",
                table: "TB_USR_USERS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_USR_USER_TOKEN",
                table: "TB_USR_USER_TOKEN");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_USR_USER_ROLE",
                table: "TB_USR_USER_ROLE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_USR_USER_LOGIN",
                table: "TB_USR_USER_LOGIN");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_USR_USER_CLAIM",
                table: "TB_USR_USER_CLAIM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_USR_ROLES",
                table: "TB_USR_ROLES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_USR_ROLE_CLAIM",
                table: "TB_USR_ROLE_CLAIM");

            migrationBuilder.DeleteData(
                table: "TB_USR_ROLES",
                keyColumn: "Id",
                keyValue: 11112);

            migrationBuilder.DeleteData(
                table: "TB_USR_USER_ROLE",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 11111, 11111 });

            migrationBuilder.DeleteData(
                table: "TB_USR_ROLES",
                keyColumn: "Id",
                keyValue: 11111);

            migrationBuilder.DeleteData(
                table: "TB_USR_USERS",
                keyColumn: "Id",
                keyValue: 11111);

            migrationBuilder.RenameTable(
                name: "TB_USR_USERS",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "TB_USR_USER_TOKEN",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "TB_USR_USER_ROLE",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "TB_USR_USER_LOGIN",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "TB_USR_USER_CLAIM",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "TB_USR_ROLES",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "TB_USR_ROLE_CLAIM",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameIndex(
                name: "IX_TB_USR_USER_ROLE_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_TB_USR_USER_LOGIN_UserId",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TB_USR_USER_CLAIM_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TB_USR_ROLE_CLAIM_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AddColumn<int>(
                name: "Balance",
                table: "TB_USR_PERSON",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TB_USR_OPERATION_TYPE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TYPE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREDIT = table.Column<bool>(type: "bit", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ALTER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USR_OPERATION_TYPE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_USR_OPERATION",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PERSON_ID = table.Column<int>(type: "int", nullable: false),
                    OPERATION_TYPE_ID = table.Column<int>(type: "int", nullable: false),
                    COINS = table.Column<int>(type: "int", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ALTER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USR_OPERATION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_USR_OPERATION_TB_USR_OPERATION_TYPE_OPERATION_TYPE_ID",
                        column: x => x.OPERATION_TYPE_ID,
                        principalTable: "TB_USR_OPERATION_TYPE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_USR_OPERATION_TB_USR_PERSON_PERSON_ID",
                        column: x => x.PERSON_ID,
                        principalTable: "TB_USR_PERSON",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "TB_USR_GENDER",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ALTER_DATE", "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 5, 20, 17, 52, 16, 462, DateTimeKind.Local).AddTicks(7148), new DateTime(2023, 5, 20, 17, 52, 16, 462, DateTimeKind.Local).AddTicks(7135), new Guid("29e548cf-b53e-4527-aa58-170779629928") });

            migrationBuilder.UpdateData(
                table: "TB_USR_GENDER",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "ALTER_DATE", "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 5, 20, 17, 52, 16, 462, DateTimeKind.Local).AddTicks(7155), new DateTime(2023, 5, 20, 17, 52, 16, 462, DateTimeKind.Local).AddTicks(7154), new Guid("7625bc27-c0b8-4f2b-86f9-b85a59a71ae7") });

            migrationBuilder.UpdateData(
                table: "TB_USR_GENDER",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "ALTER_DATE", "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 5, 20, 17, 52, 16, 462, DateTimeKind.Local).AddTicks(7159), new DateTime(2023, 5, 20, 17, 52, 16, 462, DateTimeKind.Local).AddTicks(7159), new Guid("2f6bcc31-55e8-4e71-a6cb-2fd90019220f") });

            migrationBuilder.CreateIndex(
                name: "IX_TB_USR_OPERATION_OPERATION_TYPE_ID",
                table: "TB_USR_OPERATION",
                column: "OPERATION_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USR_OPERATION_PERSON_ID",
                table: "TB_USR_OPERATION",
                column: "PERSON_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USR_PERSON_AspNetUsers_USER_ID",
                table: "TB_USR_PERSON",
                column: "USER_ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USR_USER_KEYCODE_AspNetUsers_USER_ID",
                table: "TB_USR_USER_KEYCODE",
                column: "USER_ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_USR_PERSON_AspNetUsers_USER_ID",
                table: "TB_USR_PERSON");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_USR_USER_KEYCODE_AspNetUsers_USER_ID",
                table: "TB_USR_USER_KEYCODE");

            migrationBuilder.DropTable(
                name: "TB_USR_OPERATION");

            migrationBuilder.DropTable(
                name: "TB_USR_OPERATION_TYPE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "TB_USR_PERSON");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "TB_USR_USER_TOKEN");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "TB_USR_USERS");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "TB_USR_USER_ROLE");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "TB_USR_USER_LOGIN");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "TB_USR_USER_CLAIM");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "TB_USR_ROLES");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "TB_USR_ROLE_CLAIM");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "TB_USR_USER_ROLE",
                newName: "IX_TB_USR_USER_ROLE_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "TB_USR_USER_LOGIN",
                newName: "IX_TB_USR_USER_LOGIN_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "TB_USR_USER_CLAIM",
                newName: "IX_TB_USR_USER_CLAIM_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "TB_USR_ROLE_CLAIM",
                newName: "IX_TB_USR_ROLE_CLAIM_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_USR_USER_TOKEN",
                table: "TB_USR_USER_TOKEN",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_USR_USERS",
                table: "TB_USR_USERS",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_USR_USER_ROLE",
                table: "TB_USR_USER_ROLE",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_USR_USER_LOGIN",
                table: "TB_USR_USER_LOGIN",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_USR_USER_CLAIM",
                table: "TB_USR_USER_CLAIM",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_USR_ROLES",
                table: "TB_USR_ROLES",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_USR_ROLE_CLAIM",
                table: "TB_USR_ROLE_CLAIM",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TB_USR_BALANCE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PERSON_ID = table.Column<int>(type: "int", nullable: false),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    ALTER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    STAR_COINS = table.Column<int>(type: "int", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USR_BALANCE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_USR_BALANCE_TB_USR_PERSON_PERSON_ID",
                        column: x => x.PERSON_ID,
                        principalTable: "TB_USR_PERSON",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_USR_TRANSACTION",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BALANCE_ID = table.Column<int>(type: "int", nullable: false),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    ALTER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CURRENT_BALANCE = table.Column<int>(type: "int", nullable: false),
                    NEW_BALANCE = table.Column<int>(type: "int", nullable: false),
                    OPERATION = table.Column<bool>(type: "bit", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    VALUE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USR_TRANSACTION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_USR_TRANSACTION_TB_USR_BALANCE_BALANCE_ID",
                        column: x => x.BALANCE_ID,
                        principalTable: "TB_USR_BALANCE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "TB_USR_GENDER",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ALTER_DATE", "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 5, 16, 22, 21, 24, 329, DateTimeKind.Local).AddTicks(4322), new DateTime(2023, 5, 16, 22, 21, 24, 329, DateTimeKind.Local).AddTicks(4312), new Guid("4c51f7eb-2558-4be9-bf03-2c608c1ffc86") });

            migrationBuilder.UpdateData(
                table: "TB_USR_GENDER",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "ALTER_DATE", "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 5, 16, 22, 21, 24, 329, DateTimeKind.Local).AddTicks(4327), new DateTime(2023, 5, 16, 22, 21, 24, 329, DateTimeKind.Local).AddTicks(4326), new Guid("7f197a57-41dc-43cb-bee4-3e1bc01205e4") });

            migrationBuilder.UpdateData(
                table: "TB_USR_GENDER",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "ALTER_DATE", "CREATE_DATE", "UUID" },
                values: new object[] { new DateTime(2023, 5, 16, 22, 21, 24, 329, DateTimeKind.Local).AddTicks(4329), new DateTime(2023, 5, 16, 22, 21, 24, 329, DateTimeKind.Local).AddTicks(4329), new Guid("7280c500-5363-4909-ad2c-9578bb64f093") });

            migrationBuilder.InsertData(
                table: "TB_USR_ROLES",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 11111, "b061365b-8fa7-403e-962a-15242d97d929", "admin", "ADMIN" },
                    { 11112, "b7533cbb-b092-4c56-b901-8c6e79c903a9", "standard", "STANDARD" }
                });

            migrationBuilder.InsertData(
                table: "TB_USR_USERS",
                columns: new[] { "Id", "AccessFailedCount", "Active", "AlterDate", "ConcurrencyStamp", "CreateDate", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 11111, 0, true, null, "4cd66287-1128-4acd-808f-f63a5e7c7f17", new DateTime(2023, 5, 16, 22, 21, 24, 319, DateTimeKind.Local).AddTicks(179), "projeto.mkw@gmail.com", true, "Administrador", "MyKidsWatch", false, null, "PROJETO.MWK@GMAIL.COM", "ADMIN11111", "AQAAAAEAACcQAAAAEDSsCMw4sRRN4Tqqa6xFK9droeypLNyZNNvVk1fKcsqGDfU3PXJaPMkdqVPWtlQSXA==", "5511978019550", true, "bb15160f-ba0a-4462-acf1-86c6c0e3a402", false, "admin11111" });

            migrationBuilder.InsertData(
                table: "TB_USR_USER_ROLE",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 11111, 11111 });

            migrationBuilder.CreateIndex(
                name: "IX_TB_USR_BALANCE_PERSON_ID",
                table: "TB_USR_BALANCE",
                column: "PERSON_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_USR_TRANSACTION_BALANCE_ID",
                table: "TB_USR_TRANSACTION",
                column: "BALANCE_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USR_PERSON_TB_USR_USERS_USER_ID",
                table: "TB_USR_PERSON",
                column: "USER_ID",
                principalTable: "TB_USR_USERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USR_ROLE_CLAIM_TB_USR_ROLES_RoleId",
                table: "TB_USR_ROLE_CLAIM",
                column: "RoleId",
                principalTable: "TB_USR_ROLES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USR_USER_CLAIM_TB_USR_USERS_UserId",
                table: "TB_USR_USER_CLAIM",
                column: "UserId",
                principalTable: "TB_USR_USERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USR_USER_KEYCODE_TB_USR_USERS_USER_ID",
                table: "TB_USR_USER_KEYCODE",
                column: "USER_ID",
                principalTable: "TB_USR_USERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USR_USER_LOGIN_TB_USR_USERS_UserId",
                table: "TB_USR_USER_LOGIN",
                column: "UserId",
                principalTable: "TB_USR_USERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USR_USER_ROLE_TB_USR_ROLES_RoleId",
                table: "TB_USR_USER_ROLE",
                column: "RoleId",
                principalTable: "TB_USR_ROLES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USR_USER_ROLE_TB_USR_USERS_UserId",
                table: "TB_USR_USER_ROLE",
                column: "UserId",
                principalTable: "TB_USR_USERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USR_USER_TOKEN_TB_USR_USERS_UserId",
                table: "TB_USR_USER_TOKEN",
                column: "UserId",
                principalTable: "TB_USR_USERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
