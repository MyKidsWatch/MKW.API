using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MKW.Data.Context.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgeRange",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InitialAge = table.Column<int>(type: "int", nullable: false),
                    FinalAge = table.Column<int>(type: "int", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeRange", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBinary = table.Column<bool>(type: "bit", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_MKW_GENRE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ALTER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MKW_GENRE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_MKW_PLATFORM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ALTER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MKW_PLATFORM", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_PRM_TIER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IS_PREMIUM = table.Column<bool>(type: "bit", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ALTER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRM_TIER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_PRM_TIMESPAN",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DAYS = table.Column<int>(type: "int", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ALTER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRM_TIMESPAN", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    PhoneCountry = table.Column<int>(type: "int", nullable: false),
                    PhoneArea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TB_MKW_PLATFORM_CATEGORY",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PLATFORM_ID = table.Column<int>(type: "int", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ALTER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MKW_PLATFORM_CATEGORY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_MKW_PLATFORM_CATEGORY_TB_MKW_PLATFORM_PLATFORM_ID",
                        column: x => x.PLATFORM_ID,
                        principalTable: "TB_MKW_PLATFORM",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TB_PRM_TIER_PLAN",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TIER_ID = table.Column<int>(type: "int", nullable: false),
                    TIMESPAN_ID = table.Column<int>(type: "int", nullable: false),
                    PRICE = table.Column<int>(type: "int", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ALTER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRM_TIER_PLAN", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_PRM_TIER_PLAN_TB_PRM_TIER_TIER_ID",
                        column: x => x.TIER_ID,
                        principalTable: "TB_PRM_TIER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TB_PRM_TIER_PLAN_TB_PRM_TIMESPAN_TIMESPAN_ID",
                        column: x => x.TIMESPAN_ID,
                        principalTable: "TB_PRM_TIMESPAN",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PersonChild",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    AgeRangeId = table.Column<int>(type: "int", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonChild", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonChild_AgeRange_AgeRangeId",
                        column: x => x.AgeRangeId,
                        principalTable: "AgeRange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PersonChild_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PersonChild_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TB_MKW_CONTENT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CATEGORY_ID = table.Column<int>(type: "int", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ALTER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MKW_CONTENT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_MKW_CONTENT_TB_MKW_PLATFORM_CATEGORY_CATEGORY_ID",
                        column: x => x.CATEGORY_ID,
                        principalTable: "TB_MKW_PLATFORM_CATEGORY",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TB_PRM_PREMIUM_PERSON",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PERSON_ID = table.Column<int>(type: "int", nullable: false),
                    TIER_PLAN_ID = table.Column<int>(type: "int", nullable: false),
                    START_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    END_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AUTORENEWAL = table.Column<bool>(type: "bit", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ALTER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRM_PREMIUM_PERSON", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_PRM_PREMIUM_PERSON_Person_PERSON_ID",
                        column: x => x.PERSON_ID,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TB_PRM_PREMIUM_PERSON_TB_PRM_TIER_PLAN_TIER_PLAN_ID",
                        column: x => x.TIER_PLAN_ID,
                        principalTable: "TB_PRM_TIER_PLAN",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TB_MKW_CONTENT_GENRE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CONTENT_ID = table.Column<int>(type: "int", nullable: false),
                    GENRE_ID = table.Column<int>(type: "int", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ALTER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MKW_CONTENT_GENRE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_MKW_CONTENT_GENRE_TB_MKW_CONTENT_CONTENT_ID",
                        column: x => x.CONTENT_ID,
                        principalTable: "TB_MKW_CONTENT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TB_MKW_CONTENT_GENRE_TB_MKW_GENRE_GENRE_ID",
                        column: x => x.GENRE_ID,
                        principalTable: "TB_MKW_GENRE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TB_RVW_POST",
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
                    table.PrimaryKey("PK_TB_RVW_POST", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_RVW_POST_Person_PERSON_ID",
                        column: x => x.PERSON_ID,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TB_RVW_POST_TB_MKW_CONTENT_CONTENT_ID",
                        column: x => x.CONTENT_ID,
                        principalTable: "TB_MKW_CONTENT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TB_RVW_COMMENT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PERSON_ID = table.Column<int>(type: "int", nullable: false),
                    POST_ID = table.Column<int>(type: "int", nullable: false),
                    PARENT_COMMENT_ID = table.Column<int>(type: "int", nullable: true),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ALTER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RVW_COMMENT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_RVW_COMMENT_Person_PERSON_ID",
                        column: x => x.PERSON_ID,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TB_RVW_COMMENT_TB_RVW_COMMENT_PARENT_COMMENT_ID",
                        column: x => x.PARENT_COMMENT_ID,
                        principalTable: "TB_RVW_COMMENT",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TB_RVW_COMMENT_TB_RVW_POST_POST_ID",
                        column: x => x.POST_ID,
                        principalTable: "TB_RVW_POST",
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
                    TITLE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TEXT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ALTER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "TB_RVW_COMMENT_DETAILS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COMMENT_ID = table.Column<int>(type: "int", nullable: false),
                    TEXT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ALTER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RVW_COMMENT_DETAILS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_RVW_COMMENT_DETAILS_TB_RVW_COMMENT_COMMENT_ID",
                        column: x => x.COMMENT_ID,
                        principalTable: "TB_RVW_COMMENT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_GenderId",
                table: "Person",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonChild_AgeRangeId",
                table: "PersonChild",
                column: "AgeRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonChild_GenderId",
                table: "PersonChild",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonChild_PersonId",
                table: "PersonChild",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_MKW_CONTENT_CATEGORY_ID",
                table: "TB_MKW_CONTENT",
                column: "CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_MKW_CONTENT_GENRE_CONTENT_ID",
                table: "TB_MKW_CONTENT_GENRE",
                column: "CONTENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_MKW_CONTENT_GENRE_GENRE_ID",
                table: "TB_MKW_CONTENT_GENRE",
                column: "GENRE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_MKW_PLATFORM_CATEGORY_PLATFORM_ID",
                table: "TB_MKW_PLATFORM_CATEGORY",
                column: "PLATFORM_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PRM_PREMIUM_PERSON_PERSON_ID",
                table: "TB_PRM_PREMIUM_PERSON",
                column: "PERSON_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PRM_PREMIUM_PERSON_TIER_PLAN_ID",
                table: "TB_PRM_PREMIUM_PERSON",
                column: "TIER_PLAN_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PRM_TIER_PLAN_TIER_ID",
                table: "TB_PRM_TIER_PLAN",
                column: "TIER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PRM_TIER_PLAN_TIMESPAN_ID",
                table: "TB_PRM_TIER_PLAN",
                column: "TIMESPAN_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RVW_COMMENT_PARENT_COMMENT_ID",
                table: "TB_RVW_COMMENT",
                column: "PARENT_COMMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RVW_COMMENT_PERSON_ID",
                table: "TB_RVW_COMMENT",
                column: "PERSON_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RVW_COMMENT_POST_ID",
                table: "TB_RVW_COMMENT",
                column: "POST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RVW_COMMENT_DETAILS_COMMENT_ID",
                table: "TB_RVW_COMMENT_DETAILS",
                column: "COMMENT_ID");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonChild");

            migrationBuilder.DropTable(
                name: "TB_MKW_CONTENT_GENRE");

            migrationBuilder.DropTable(
                name: "TB_PRM_PREMIUM_PERSON");

            migrationBuilder.DropTable(
                name: "TB_RVW_COMMENT_DETAILS");

            migrationBuilder.DropTable(
                name: "TB_RVW_POST_DETAILS");

            migrationBuilder.DropTable(
                name: "AgeRange");

            migrationBuilder.DropTable(
                name: "TB_MKW_GENRE");

            migrationBuilder.DropTable(
                name: "TB_PRM_TIER_PLAN");

            migrationBuilder.DropTable(
                name: "TB_RVW_COMMENT");

            migrationBuilder.DropTable(
                name: "TB_PRM_TIER");

            migrationBuilder.DropTable(
                name: "TB_PRM_TIMESPAN");

            migrationBuilder.DropTable(
                name: "TB_RVW_POST");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "TB_MKW_CONTENT");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "TB_MKW_PLATFORM_CATEGORY");

            migrationBuilder.DropTable(
                name: "TB_MKW_PLATFORM");
        }
    }
}
