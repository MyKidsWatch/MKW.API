using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MKW.Data.Context.Migrations
{
    /// <inheritdoc />
    public partial class NewEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AwardPerson_Award_AwardId",
                table: "AwardPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_AwardPerson_TB_RVW_POST_ReviewId",
                table: "AwardPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_AwardPerson_TB_USR_PERSON_PersonId",
                table: "AwardPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_Balance_TB_USR_PERSON_PersonId",
                table: "Balance");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_RVW_COMMENT_TB_RVW_POST_POST_ID",
                table: "TB_RVW_COMMENT");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Balance_BalanceId",
                table: "Transaction");

            migrationBuilder.DropTable(
                name: "TB_RVW_POST_DETAILS");

            migrationBuilder.DropTable(
                name: "TB_RVW_POST");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Balance",
                table: "Balance");

            migrationBuilder.DropIndex(
                name: "IX_Balance_PersonId",
                table: "Balance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AwardPerson",
                table: "AwardPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Award",
                table: "Award");

            migrationBuilder.RenameTable(
                name: "Transaction",
                newName: "TB_USR_TRANSACTION");

            migrationBuilder.RenameTable(
                name: "Balance",
                newName: "TB_USR_BALANCE");

            migrationBuilder.RenameTable(
                name: "AwardPerson",
                newName: "TB_RVW_AWARD_PERSON");

            migrationBuilder.RenameTable(
                name: "Award",
                newName: "TB_RVW_AWARD");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "TB_USR_TRANSACTION",
                newName: "VALUE");

            migrationBuilder.RenameColumn(
                name: "Operation",
                table: "TB_USR_TRANSACTION",
                newName: "OPERATION");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "TB_USR_TRANSACTION",
                newName: "ACTIVE");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TB_USR_TRANSACTION",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "NewBalance",
                table: "TB_USR_TRANSACTION",
                newName: "NEW_BALANCE");

            migrationBuilder.RenameColumn(
                name: "CurrentBalance",
                table: "TB_USR_TRANSACTION",
                newName: "CURRENT_BALANCE");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "TB_USR_TRANSACTION",
                newName: "CREATE_DATE");

            migrationBuilder.RenameColumn(
                name: "BalanceId",
                table: "TB_USR_TRANSACTION",
                newName: "BALANCE_ID");

            migrationBuilder.RenameColumn(
                name: "AlterDate",
                table: "TB_USR_TRANSACTION",
                newName: "ALTER_DATE");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_BalanceId",
                table: "TB_USR_TRANSACTION",
                newName: "IX_TB_USR_TRANSACTION_BALANCE_ID");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "TB_USR_BALANCE",
                newName: "ACTIVE");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TB_USR_BALANCE",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "StarCoins",
                table: "TB_USR_BALANCE",
                newName: "STAR_COINS");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "TB_USR_BALANCE",
                newName: "PERSON_ID");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "TB_USR_BALANCE",
                newName: "CREATE_DATE");

            migrationBuilder.RenameColumn(
                name: "AlterDate",
                table: "TB_USR_BALANCE",
                newName: "ALTER_DATE");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "TB_RVW_AWARD_PERSON",
                newName: "ACTIVE");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TB_RVW_AWARD_PERSON",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ReviewId",
                table: "TB_RVW_AWARD_PERSON",
                newName: "REVIEW_ID");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "TB_RVW_AWARD_PERSON",
                newName: "PERSON_ID");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "TB_RVW_AWARD_PERSON",
                newName: "CREATE_DATE");

            migrationBuilder.RenameColumn(
                name: "AwardId",
                table: "TB_RVW_AWARD_PERSON",
                newName: "AWARD_ID");

            migrationBuilder.RenameColumn(
                name: "AlterDate",
                table: "TB_RVW_AWARD_PERSON",
                newName: "ALTER_DATE");

            migrationBuilder.RenameIndex(
                name: "IX_AwardPerson_ReviewId",
                table: "TB_RVW_AWARD_PERSON",
                newName: "IX_TB_RVW_AWARD_PERSON_REVIEW_ID");

            migrationBuilder.RenameIndex(
                name: "IX_AwardPerson_PersonId",
                table: "TB_RVW_AWARD_PERSON",
                newName: "IX_TB_RVW_AWARD_PERSON_PERSON_ID");

            migrationBuilder.RenameIndex(
                name: "IX_AwardPerson_AwardId",
                table: "TB_RVW_AWARD_PERSON",
                newName: "IX_TB_RVW_AWARD_PERSON_AWARD_ID");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "TB_RVW_AWARD",
                newName: "VALUE");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "TB_RVW_AWARD",
                newName: "PRICE");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "TB_RVW_AWARD",
                newName: "ACTIVE");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TB_RVW_AWARD",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "TB_RVW_AWARD",
                newName: "CREATE_DATE");

            migrationBuilder.RenameColumn(
                name: "AlterDate",
                table: "TB_RVW_AWARD",
                newName: "ALTER_DATE");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_USR_TRANSACTION",
                table: "TB_USR_TRANSACTION",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_USR_BALANCE",
                table: "TB_USR_BALANCE",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_RVW_AWARD_PERSON",
                table: "TB_RVW_AWARD_PERSON",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_RVW_AWARD",
                table: "TB_RVW_AWARD",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "TB_RVW_REVIEW",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PERSON_ID = table.Column<int>(type: "int", nullable: false),
                    CONTENT_ID = table.Column<int>(type: "int", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ALTER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RVW_REVIEW", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_RVW_REVIEW_TB_MKW_CONTENT_CONTENT_ID",
                        column: x => x.CONTENT_ID,
                        principalTable: "TB_MKW_CONTENT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TB_RVW_REVIEW_TB_USR_PERSON_PERSON_ID",
                        column: x => x.PERSON_ID,
                        principalTable: "TB_USR_PERSON",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TB_RVW_REVIEW_DETAILS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    POST_ID = table.Column<int>(type: "int", nullable: false),
                    TITLE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TEXT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ALTER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RVW_REVIEW_DETAILS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_RVW_REVIEW_DETAILS_TB_RVW_REVIEW_POST_ID",
                        column: x => x.POST_ID,
                        principalTable: "TB_RVW_REVIEW",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_USR_BALANCE_PERSON_ID",
                table: "TB_USR_BALANCE",
                column: "PERSON_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_RVW_REVIEW_CONTENT_ID",
                table: "TB_RVW_REVIEW",
                column: "CONTENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RVW_REVIEW_PERSON_ID",
                table: "TB_RVW_REVIEW",
                column: "PERSON_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RVW_REVIEW_DETAILS_POST_ID",
                table: "TB_RVW_REVIEW_DETAILS",
                column: "POST_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_RVW_AWARD_PERSON_TB_RVW_AWARD_AWARD_ID",
                table: "TB_RVW_AWARD_PERSON",
                column: "AWARD_ID",
                principalTable: "TB_RVW_AWARD",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_RVW_AWARD_PERSON_TB_RVW_REVIEW_REVIEW_ID",
                table: "TB_RVW_AWARD_PERSON",
                column: "REVIEW_ID",
                principalTable: "TB_RVW_REVIEW",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_RVW_AWARD_PERSON_TB_USR_PERSON_PERSON_ID",
                table: "TB_RVW_AWARD_PERSON",
                column: "PERSON_ID",
                principalTable: "TB_USR_PERSON",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_RVW_COMMENT_TB_RVW_REVIEW_POST_ID",
                table: "TB_RVW_COMMENT",
                column: "POST_ID",
                principalTable: "TB_RVW_REVIEW",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USR_BALANCE_TB_USR_PERSON_PERSON_ID",
                table: "TB_USR_BALANCE",
                column: "PERSON_ID",
                principalTable: "TB_USR_PERSON",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_USR_TRANSACTION_TB_USR_BALANCE_BALANCE_ID",
                table: "TB_USR_TRANSACTION",
                column: "BALANCE_ID",
                principalTable: "TB_USR_BALANCE",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_RVW_AWARD_PERSON_TB_RVW_AWARD_AWARD_ID",
                table: "TB_RVW_AWARD_PERSON");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_RVW_AWARD_PERSON_TB_RVW_REVIEW_REVIEW_ID",
                table: "TB_RVW_AWARD_PERSON");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_RVW_AWARD_PERSON_TB_USR_PERSON_PERSON_ID",
                table: "TB_RVW_AWARD_PERSON");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_RVW_COMMENT_TB_RVW_REVIEW_POST_ID",
                table: "TB_RVW_COMMENT");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_USR_BALANCE_TB_USR_PERSON_PERSON_ID",
                table: "TB_USR_BALANCE");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_USR_TRANSACTION_TB_USR_BALANCE_BALANCE_ID",
                table: "TB_USR_TRANSACTION");

            migrationBuilder.DropTable(
                name: "TB_RVW_REVIEW_DETAILS");

            migrationBuilder.DropTable(
                name: "TB_RVW_REVIEW");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_USR_TRANSACTION",
                table: "TB_USR_TRANSACTION");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_USR_BALANCE",
                table: "TB_USR_BALANCE");

            migrationBuilder.DropIndex(
                name: "IX_TB_USR_BALANCE_PERSON_ID",
                table: "TB_USR_BALANCE");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_RVW_AWARD_PERSON",
                table: "TB_RVW_AWARD_PERSON");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_RVW_AWARD",
                table: "TB_RVW_AWARD");

            migrationBuilder.RenameTable(
                name: "TB_USR_TRANSACTION",
                newName: "Transaction");

            migrationBuilder.RenameTable(
                name: "TB_USR_BALANCE",
                newName: "Balance");

            migrationBuilder.RenameTable(
                name: "TB_RVW_AWARD_PERSON",
                newName: "AwardPerson");

            migrationBuilder.RenameTable(
                name: "TB_RVW_AWARD",
                newName: "Award");

            migrationBuilder.RenameColumn(
                name: "VALUE",
                table: "Transaction",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "OPERATION",
                table: "Transaction",
                newName: "Operation");

            migrationBuilder.RenameColumn(
                name: "ACTIVE",
                table: "Transaction",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Transaction",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "NEW_BALANCE",
                table: "Transaction",
                newName: "NewBalance");

            migrationBuilder.RenameColumn(
                name: "CURRENT_BALANCE",
                table: "Transaction",
                newName: "CurrentBalance");

            migrationBuilder.RenameColumn(
                name: "CREATE_DATE",
                table: "Transaction",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "BALANCE_ID",
                table: "Transaction",
                newName: "BalanceId");

            migrationBuilder.RenameColumn(
                name: "ALTER_DATE",
                table: "Transaction",
                newName: "AlterDate");

            migrationBuilder.RenameIndex(
                name: "IX_TB_USR_TRANSACTION_BALANCE_ID",
                table: "Transaction",
                newName: "IX_Transaction_BalanceId");

            migrationBuilder.RenameColumn(
                name: "ACTIVE",
                table: "Balance",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Balance",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "STAR_COINS",
                table: "Balance",
                newName: "StarCoins");

            migrationBuilder.RenameColumn(
                name: "PERSON_ID",
                table: "Balance",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "CREATE_DATE",
                table: "Balance",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "ALTER_DATE",
                table: "Balance",
                newName: "AlterDate");

            migrationBuilder.RenameColumn(
                name: "ACTIVE",
                table: "AwardPerson",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "AwardPerson",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "REVIEW_ID",
                table: "AwardPerson",
                newName: "ReviewId");

            migrationBuilder.RenameColumn(
                name: "PERSON_ID",
                table: "AwardPerson",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "CREATE_DATE",
                table: "AwardPerson",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "AWARD_ID",
                table: "AwardPerson",
                newName: "AwardId");

            migrationBuilder.RenameColumn(
                name: "ALTER_DATE",
                table: "AwardPerson",
                newName: "AlterDate");

            migrationBuilder.RenameIndex(
                name: "IX_TB_RVW_AWARD_PERSON_REVIEW_ID",
                table: "AwardPerson",
                newName: "IX_AwardPerson_ReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_TB_RVW_AWARD_PERSON_PERSON_ID",
                table: "AwardPerson",
                newName: "IX_AwardPerson_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_TB_RVW_AWARD_PERSON_AWARD_ID",
                table: "AwardPerson",
                newName: "IX_AwardPerson_AwardId");

            migrationBuilder.RenameColumn(
                name: "VALUE",
                table: "Award",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "PRICE",
                table: "Award",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "ACTIVE",
                table: "Award",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Award",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CREATE_DATE",
                table: "Award",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "ALTER_DATE",
                table: "Award",
                newName: "AlterDate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transaction",
                table: "Transaction",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Balance",
                table: "Balance",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AwardPerson",
                table: "AwardPerson",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Award",
                table: "Award",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TB_RVW_POST",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CONTENT_ID = table.Column<int>(type: "int", nullable: false),
                    PERSON_ID = table.Column<int>(type: "int", nullable: false),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    ALTER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RVW_POST", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_RVW_POST_TB_MKW_CONTENT_CONTENT_ID",
                        column: x => x.CONTENT_ID,
                        principalTable: "TB_MKW_CONTENT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TB_RVW_POST_TB_USR_PERSON_PERSON_ID",
                        column: x => x.PERSON_ID,
                        principalTable: "TB_USR_PERSON",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TB_RVW_POST_DETAILS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    POST_ID = table.Column<int>(type: "int", nullable: false),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false),
                    ALTER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TEXT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TITLE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RVW_POST_DETAILS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_RVW_POST_DETAILS_TB_RVW_POST_POST_ID",
                        column: x => x.POST_ID,
                        principalTable: "TB_RVW_POST",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Balance_PersonId",
                table: "Balance",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RVW_POST_CONTENT_ID",
                table: "TB_RVW_POST",
                column: "CONTENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RVW_POST_PERSON_ID",
                table: "TB_RVW_POST",
                column: "PERSON_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RVW_POST_DETAILS_POST_ID",
                table: "TB_RVW_POST_DETAILS",
                column: "POST_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AwardPerson_Award_AwardId",
                table: "AwardPerson",
                column: "AwardId",
                principalTable: "Award",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AwardPerson_TB_RVW_POST_ReviewId",
                table: "AwardPerson",
                column: "ReviewId",
                principalTable: "TB_RVW_POST",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_AwardPerson_TB_USR_PERSON_PersonId",
                table: "AwardPerson",
                column: "PersonId",
                principalTable: "TB_USR_PERSON",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Balance_TB_USR_PERSON_PersonId",
                table: "Balance",
                column: "PersonId",
                principalTable: "TB_USR_PERSON",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_RVW_COMMENT_TB_RVW_POST_POST_ID",
                table: "TB_RVW_COMMENT",
                column: "POST_ID",
                principalTable: "TB_RVW_POST",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Balance_BalanceId",
                table: "Transaction",
                column: "BalanceId",
                principalTable: "Balance",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
