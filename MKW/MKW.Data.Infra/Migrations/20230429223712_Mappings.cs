using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MKW.Data.Context.Migrations
{
    /// <inheritdoc />
    public partial class Mappings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Gender_GenderId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonChild_AgeRange_AgeRangeId",
                table: "PersonChild");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonChild_Gender_GenderId",
                table: "PersonChild");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonChild_Person_PersonId",
                table: "PersonChild");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_PRM_PREMIUM_PERSON_Person_PERSON_ID",
                table: "TB_PRM_PREMIUM_PERSON");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_RVW_COMMENT_Person_PERSON_ID",
                table: "TB_RVW_COMMENT");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_RVW_POST_Person_PERSON_ID",
                table: "TB_RVW_POST");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonChild",
                table: "PersonChild");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gender",
                table: "Gender");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AgeRange",
                table: "AgeRange");

            migrationBuilder.RenameTable(
                name: "PersonChild",
                newName: "TB_USR_PERSON_CHILD");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "TB_USR_PERSON");

            migrationBuilder.RenameTable(
                name: "Gender",
                newName: "TB_USR_GENDER");

            migrationBuilder.RenameTable(
                name: "AgeRange",
                newName: "TB_USR_AGE_RANGE");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "TB_USR_PERSON_CHILD",
                newName: "ACTIVE");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TB_USR_PERSON_CHILD",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "TB_USR_PERSON_CHILD",
                newName: "PERSON_ID");

            migrationBuilder.RenameColumn(
                name: "GenderId",
                table: "TB_USR_PERSON_CHILD",
                newName: "GENDER_ID");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "TB_USR_PERSON_CHILD",
                newName: "CREATE_DATE");

            migrationBuilder.RenameColumn(
                name: "AlterDate",
                table: "TB_USR_PERSON_CHILD",
                newName: "ALTER_DATE");

            migrationBuilder.RenameColumn(
                name: "AgeRangeId",
                table: "TB_USR_PERSON_CHILD",
                newName: "AGE_RANGE_ID");

            migrationBuilder.RenameIndex(
                name: "IX_PersonChild_PersonId",
                table: "TB_USR_PERSON_CHILD",
                newName: "IX_TB_USR_PERSON_CHILD_PERSON_ID");

            migrationBuilder.RenameIndex(
                name: "IX_PersonChild_GenderId",
                table: "TB_USR_PERSON_CHILD",
                newName: "IX_TB_USR_PERSON_CHILD_GENDER_ID");

            migrationBuilder.RenameIndex(
                name: "IX_PersonChild_AgeRangeId",
                table: "TB_USR_PERSON_CHILD",
                newName: "IX_TB_USR_PERSON_CHILD_AGE_RANGE_ID");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "TB_USR_PERSON",
                newName: "USERNAME");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "TB_USR_PERSON",
                newName: "PASSWORD");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TB_USR_PERSON",
                newName: "NAME");

            migrationBuilder.RenameColumn(
                name: "Hash",
                table: "TB_USR_PERSON",
                newName: "HASH");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "TB_USR_PERSON",
                newName: "EMAIL");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "TB_USR_PERSON",
                newName: "ACTIVE");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TB_USR_PERSON",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "TB_USR_PERSON",
                newName: "PHONE_NUMBER");

            migrationBuilder.RenameColumn(
                name: "PhoneCountry",
                table: "TB_USR_PERSON",
                newName: "PHONE_COUNTRY");

            migrationBuilder.RenameColumn(
                name: "PhoneArea",
                table: "TB_USR_PERSON",
                newName: "PHONE_AREA");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "TB_USR_PERSON",
                newName: "SURNAME");

            migrationBuilder.RenameColumn(
                name: "GenderId",
                table: "TB_USR_PERSON",
                newName: "GENDER_ID");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "TB_USR_PERSON",
                newName: "CREATE_DATE");

            migrationBuilder.RenameColumn(
                name: "AlterDate",
                table: "TB_USR_PERSON",
                newName: "ALTER_DATE");

            migrationBuilder.RenameIndex(
                name: "IX_Person_GenderId",
                table: "TB_USR_PERSON",
                newName: "IX_TB_USR_PERSON_GENDER_ID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TB_USR_GENDER",
                newName: "NAME");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "TB_USR_GENDER",
                newName: "ACTIVE");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TB_USR_GENDER",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "IsBinary",
                table: "TB_USR_GENDER",
                newName: "IS_BINARY");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "TB_USR_GENDER",
                newName: "CREATE_DATE");

            migrationBuilder.RenameColumn(
                name: "AlterDate",
                table: "TB_USR_GENDER",
                newName: "ALTER_DATE");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "TB_USR_AGE_RANGE",
                newName: "ACTIVE");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TB_USR_AGE_RANGE",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "InitialAge",
                table: "TB_USR_AGE_RANGE",
                newName: "INITIAL_AGE");

            migrationBuilder.RenameColumn(
                name: "FinalAge",
                table: "TB_USR_AGE_RANGE",
                newName: "FINAL_AGE");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "TB_USR_AGE_RANGE",
                newName: "CREATE_DATE");

            migrationBuilder.RenameColumn(
                name: "AlterDate",
                table: "TB_USR_AGE_RANGE",
                newName: "ALTER_DATE");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_USR_PERSON_CHILD",
                table: "TB_USR_PERSON_CHILD",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_USR_PERSON",
                table: "TB_USR_PERSON",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_USR_GENDER",
                table: "TB_USR_GENDER",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_USR_AGE_RANGE",
                table: "TB_USR_AGE_RANGE",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Award",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Award", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Balance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    StarCoins = table.Column<int>(type: "int", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Balance_TB_USR_PERSON_PersonId",
                        column: x => x.PersonId,
                        principalTable: "TB_USR_PERSON",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "AwardPerson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    ReviewId = table.Column<int>(type: "int", nullable: false),
                    AwardId = table.Column<int>(type: "int", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwardPerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AwardPerson_Award_AwardId",
                        column: x => x.AwardId,
                        principalTable: "Award",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AwardPerson_TB_RVW_POST_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "TB_RVW_POST",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AwardPerson_TB_USR_PERSON_PersonId",
                        column: x => x.PersonId,
                        principalTable: "TB_USR_PERSON",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BalanceId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Operation = table.Column<bool>(type: "bit", nullable: false),
                    CurrentBalance = table.Column<int>(type: "int", nullable: false),
                    NewBalance = table.Column<int>(type: "int", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_Balance_BalanceId",
                        column: x => x.BalanceId,
                        principalTable: "Balance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AwardPerson_AwardId",
                table: "AwardPerson",
                column: "AwardId");

            migrationBuilder.CreateIndex(
                name: "IX_AwardPerson_PersonId",
                table: "AwardPerson",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_AwardPerson_ReviewId",
                table: "AwardPerson",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Balance_PersonId",
                table: "Balance",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_BalanceId",
                table: "Transaction",
                column: "BalanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PRM_PREMIUM_PERSON_TB_USR_PERSON_PERSON_ID",
                table: "TB_PRM_PREMIUM_PERSON",
                column: "PERSON_ID",
                principalTable: "TB_USR_PERSON",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_RVW_COMMENT_TB_USR_PERSON_PERSON_ID",
                table: "TB_RVW_COMMENT",
                column: "PERSON_ID",
                principalTable: "TB_USR_PERSON",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_RVW_POST_TB_USR_PERSON_PERSON_ID",
                table: "TB_RVW_POST",
                column: "PERSON_ID",
                principalTable: "TB_USR_PERSON",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USR_PERSON_TB_USR_GENDER_GENDER_ID",
                table: "TB_USR_PERSON",
                column: "GENDER_ID",
                principalTable: "TB_USR_GENDER",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USR_PERSON_CHILD_TB_USR_AGE_RANGE_AGE_RANGE_ID",
                table: "TB_USR_PERSON_CHILD",
                column: "AGE_RANGE_ID",
                principalTable: "TB_USR_AGE_RANGE",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USR_PERSON_CHILD_TB_USR_GENDER_GENDER_ID",
                table: "TB_USR_PERSON_CHILD",
                column: "GENDER_ID",
                principalTable: "TB_USR_GENDER",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USR_PERSON_CHILD_TB_USR_PERSON_PERSON_ID",
                table: "TB_USR_PERSON_CHILD",
                column: "PERSON_ID",
                principalTable: "TB_USR_PERSON",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_PRM_PREMIUM_PERSON_TB_USR_PERSON_PERSON_ID",
                table: "TB_PRM_PREMIUM_PERSON");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_RVW_COMMENT_TB_USR_PERSON_PERSON_ID",
                table: "TB_RVW_COMMENT");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_RVW_POST_TB_USR_PERSON_PERSON_ID",
                table: "TB_RVW_POST");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_USR_PERSON_TB_USR_GENDER_GENDER_ID",
                table: "TB_USR_PERSON");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_USR_PERSON_CHILD_TB_USR_AGE_RANGE_AGE_RANGE_ID",
                table: "TB_USR_PERSON_CHILD");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_USR_PERSON_CHILD_TB_USR_GENDER_GENDER_ID",
                table: "TB_USR_PERSON_CHILD");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_USR_PERSON_CHILD_TB_USR_PERSON_PERSON_ID",
                table: "TB_USR_PERSON_CHILD");

            migrationBuilder.DropTable(
                name: "AwardPerson");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Award");

            migrationBuilder.DropTable(
                name: "Balance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_USR_PERSON_CHILD",
                table: "TB_USR_PERSON_CHILD");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_USR_PERSON",
                table: "TB_USR_PERSON");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_USR_GENDER",
                table: "TB_USR_GENDER");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_USR_AGE_RANGE",
                table: "TB_USR_AGE_RANGE");

            migrationBuilder.RenameTable(
                name: "TB_USR_PERSON_CHILD",
                newName: "PersonChild");

            migrationBuilder.RenameTable(
                name: "TB_USR_PERSON",
                newName: "Person");

            migrationBuilder.RenameTable(
                name: "TB_USR_GENDER",
                newName: "Gender");

            migrationBuilder.RenameTable(
                name: "TB_USR_AGE_RANGE",
                newName: "AgeRange");

            migrationBuilder.RenameColumn(
                name: "ACTIVE",
                table: "PersonChild",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "PersonChild",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PERSON_ID",
                table: "PersonChild",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "GENDER_ID",
                table: "PersonChild",
                newName: "GenderId");

            migrationBuilder.RenameColumn(
                name: "CREATE_DATE",
                table: "PersonChild",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "ALTER_DATE",
                table: "PersonChild",
                newName: "AlterDate");

            migrationBuilder.RenameColumn(
                name: "AGE_RANGE_ID",
                table: "PersonChild",
                newName: "AgeRangeId");

            migrationBuilder.RenameIndex(
                name: "IX_TB_USR_PERSON_CHILD_PERSON_ID",
                table: "PersonChild",
                newName: "IX_PersonChild_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_TB_USR_PERSON_CHILD_GENDER_ID",
                table: "PersonChild",
                newName: "IX_PersonChild_GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_TB_USR_PERSON_CHILD_AGE_RANGE_ID",
                table: "PersonChild",
                newName: "IX_PersonChild_AgeRangeId");

            migrationBuilder.RenameColumn(
                name: "USERNAME",
                table: "Person",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "PASSWORD",
                table: "Person",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "Person",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "HASH",
                table: "Person",
                newName: "Hash");

            migrationBuilder.RenameColumn(
                name: "EMAIL",
                table: "Person",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "ACTIVE",
                table: "Person",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Person",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SURNAME",
                table: "Person",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "PHONE_NUMBER",
                table: "Person",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "PHONE_COUNTRY",
                table: "Person",
                newName: "PhoneCountry");

            migrationBuilder.RenameColumn(
                name: "PHONE_AREA",
                table: "Person",
                newName: "PhoneArea");

            migrationBuilder.RenameColumn(
                name: "GENDER_ID",
                table: "Person",
                newName: "GenderId");

            migrationBuilder.RenameColumn(
                name: "CREATE_DATE",
                table: "Person",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "ALTER_DATE",
                table: "Person",
                newName: "AlterDate");

            migrationBuilder.RenameIndex(
                name: "IX_TB_USR_PERSON_GENDER_ID",
                table: "Person",
                newName: "IX_Person_GenderId");

            migrationBuilder.RenameColumn(
                name: "NAME",
                table: "Gender",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ACTIVE",
                table: "Gender",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Gender",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IS_BINARY",
                table: "Gender",
                newName: "IsBinary");

            migrationBuilder.RenameColumn(
                name: "CREATE_DATE",
                table: "Gender",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "ALTER_DATE",
                table: "Gender",
                newName: "AlterDate");

            migrationBuilder.RenameColumn(
                name: "ACTIVE",
                table: "AgeRange",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "AgeRange",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "INITIAL_AGE",
                table: "AgeRange",
                newName: "InitialAge");

            migrationBuilder.RenameColumn(
                name: "FINAL_AGE",
                table: "AgeRange",
                newName: "FinalAge");

            migrationBuilder.RenameColumn(
                name: "CREATE_DATE",
                table: "AgeRange",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "ALTER_DATE",
                table: "AgeRange",
                newName: "AlterDate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonChild",
                table: "PersonChild",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gender",
                table: "Gender",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AgeRange",
                table: "AgeRange",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Gender_GenderId",
                table: "Person",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonChild_AgeRange_AgeRangeId",
                table: "PersonChild",
                column: "AgeRangeId",
                principalTable: "AgeRange",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonChild_Gender_GenderId",
                table: "PersonChild",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonChild_Person_PersonId",
                table: "PersonChild",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PRM_PREMIUM_PERSON_Person_PERSON_ID",
                table: "TB_PRM_PREMIUM_PERSON",
                column: "PERSON_ID",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_RVW_COMMENT_Person_PERSON_ID",
                table: "TB_RVW_COMMENT",
                column: "PERSON_ID",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_RVW_POST_Person_PERSON_ID",
                table: "TB_RVW_POST",
                column: "PERSON_ID",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
