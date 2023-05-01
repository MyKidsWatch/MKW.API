using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MKW.Data.Context.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "TB_RVW_AWARD",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PRICE = table.Column<int>(type: "int", nullable: false),
                    VALUE = table.Column<int>(type: "int", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ALTER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RVW_AWARD", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_USR_AGE_RANGE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INITIAL_AGE = table.Column<int>(type: "int", nullable: false),
                    FINAL_AGE = table.Column<int>(type: "int", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ALTER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USR_AGE_RANGE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_USR_GENDER",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IS_BINARY = table.Column<bool>(type: "bit", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ALTER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USR_GENDER", x => x.ID);
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
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PRM_TIER_PLAN_TB_PRM_TIMESPAN_TIMESPAN_ID",
                        column: x => x.TIMESPAN_ID,
                        principalTable: "TB_PRM_TIMESPAN",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_USR_PERSON",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USERNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SURNAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HASH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GENDER_ID = table.Column<int>(type: "int", nullable: false),
                    PHONE_COUNTRY = table.Column<int>(type: "int", nullable: false),
                    PHONE_AREA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PHONE_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PASSWORD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ALTER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USR_PERSON", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_USR_PERSON_TB_USR_GENDER_GENDER_ID",
                        column: x => x.GENDER_ID,
                        principalTable: "TB_USR_GENDER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_TB_PRM_PREMIUM_PERSON_TB_PRM_TIER_PLAN_TIER_PLAN_ID",
                        column: x => x.TIER_PLAN_ID,
                        principalTable: "TB_PRM_TIER_PLAN",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PRM_PREMIUM_PERSON_TB_USR_PERSON_PERSON_ID",
                        column: x => x.PERSON_ID,
                        principalTable: "TB_USR_PERSON",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_USR_BALANCE",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PERSON_ID = table.Column<int>(type: "int", nullable: false),
                    STAR_COINS = table.Column<int>(type: "int", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ALTER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false)
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
                name: "TB_USR_PERSON_CHILD",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PERSON_ID = table.Column<int>(type: "int", nullable: false),
                    GENDER_ID = table.Column<int>(type: "int", nullable: false),
                    AGE_RANGE_ID = table.Column<int>(type: "int", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ALTER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USR_PERSON_CHILD", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_USR_PERSON_CHILD_TB_USR_AGE_RANGE_AGE_RANGE_ID",
                        column: x => x.AGE_RANGE_ID,
                        principalTable: "TB_USR_AGE_RANGE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_USR_PERSON_CHILD_TB_USR_GENDER_GENDER_ID",
                        column: x => x.GENDER_ID,
                        principalTable: "TB_USR_GENDER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_USR_PERSON_CHILD_TB_USR_PERSON_PERSON_ID",
                        column: x => x.PERSON_ID,
                        principalTable: "TB_USR_PERSON",
                        principalColumn: "ID");
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_MKW_CONTENT_GENRE_TB_MKW_GENRE_GENRE_ID",
                        column: x => x.GENRE_ID,
                        principalTable: "TB_MKW_GENRE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_RVW_REVIEW_TB_USR_PERSON_PERSON_ID",
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
                    VALUE = table.Column<int>(type: "int", nullable: false),
                    OPERATION = table.Column<bool>(type: "bit", nullable: false),
                    CURRENT_BALANCE = table.Column<int>(type: "int", nullable: false),
                    NEW_BALANCE = table.Column<int>(type: "int", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ALTER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "TB_RVW_AWARD_PERSON",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PERSON_ID = table.Column<int>(type: "int", nullable: false),
                    REVIEW_ID = table.Column<int>(type: "int", nullable: false),
                    AWARD_ID = table.Column<int>(type: "int", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ALTER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RVW_AWARD_PERSON", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_RVW_AWARD_PERSON_TB_RVW_AWARD_AWARD_ID",
                        column: x => x.AWARD_ID,
                        principalTable: "TB_RVW_AWARD",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_RVW_AWARD_PERSON_TB_RVW_REVIEW_REVIEW_ID",
                        column: x => x.REVIEW_ID,
                        principalTable: "TB_RVW_REVIEW",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_RVW_AWARD_PERSON_TB_USR_PERSON_PERSON_ID",
                        column: x => x.PERSON_ID,
                        principalTable: "TB_USR_PERSON",
                        principalColumn: "ID");
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
                        name: "FK_TB_RVW_COMMENT_TB_RVW_COMMENT_PARENT_COMMENT_ID",
                        column: x => x.PARENT_COMMENT_ID,
                        principalTable: "TB_RVW_COMMENT",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TB_RVW_COMMENT_TB_RVW_REVIEW_POST_ID",
                        column: x => x.POST_ID,
                        principalTable: "TB_RVW_REVIEW",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_RVW_COMMENT_TB_USR_PERSON_PERSON_ID",
                        column: x => x.PERSON_ID,
                        principalTable: "TB_USR_PERSON",
                        principalColumn: "ID");
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
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_TB_RVW_AWARD_PERSON_AWARD_ID",
                table: "TB_RVW_AWARD_PERSON",
                column: "AWARD_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RVW_AWARD_PERSON_PERSON_ID",
                table: "TB_RVW_AWARD_PERSON",
                column: "PERSON_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RVW_AWARD_PERSON_REVIEW_ID",
                table: "TB_RVW_AWARD_PERSON",
                column: "REVIEW_ID");

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

            migrationBuilder.CreateIndex(
                name: "IX_TB_USR_BALANCE_PERSON_ID",
                table: "TB_USR_BALANCE",
                column: "PERSON_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_USR_PERSON_GENDER_ID",
                table: "TB_USR_PERSON",
                column: "GENDER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USR_PERSON_CHILD_AGE_RANGE_ID",
                table: "TB_USR_PERSON_CHILD",
                column: "AGE_RANGE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USR_PERSON_CHILD_GENDER_ID",
                table: "TB_USR_PERSON_CHILD",
                column: "GENDER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USR_PERSON_CHILD_PERSON_ID",
                table: "TB_USR_PERSON_CHILD",
                column: "PERSON_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USR_TRANSACTION_BALANCE_ID",
                table: "TB_USR_TRANSACTION",
                column: "BALANCE_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_MKW_CONTENT_GENRE");

            migrationBuilder.DropTable(
                name: "TB_PRM_PREMIUM_PERSON");

            migrationBuilder.DropTable(
                name: "TB_RVW_AWARD_PERSON");

            migrationBuilder.DropTable(
                name: "TB_RVW_COMMENT_DETAILS");

            migrationBuilder.DropTable(
                name: "TB_RVW_REVIEW_DETAILS");

            migrationBuilder.DropTable(
                name: "TB_USR_PERSON_CHILD");

            migrationBuilder.DropTable(
                name: "TB_USR_TRANSACTION");

            migrationBuilder.DropTable(
                name: "TB_MKW_GENRE");

            migrationBuilder.DropTable(
                name: "TB_PRM_TIER_PLAN");

            migrationBuilder.DropTable(
                name: "TB_RVW_AWARD");

            migrationBuilder.DropTable(
                name: "TB_RVW_COMMENT");

            migrationBuilder.DropTable(
                name: "TB_USR_AGE_RANGE");

            migrationBuilder.DropTable(
                name: "TB_USR_BALANCE");

            migrationBuilder.DropTable(
                name: "TB_PRM_TIER");

            migrationBuilder.DropTable(
                name: "TB_PRM_TIMESPAN");

            migrationBuilder.DropTable(
                name: "TB_RVW_REVIEW");

            migrationBuilder.DropTable(
                name: "TB_MKW_CONTENT");

            migrationBuilder.DropTable(
                name: "TB_USR_PERSON");

            migrationBuilder.DropTable(
                name: "TB_MKW_PLATFORM_CATEGORY");

            migrationBuilder.DropTable(
                name: "TB_USR_GENDER");

            migrationBuilder.DropTable(
                name: "TB_MKW_PLATFORM");
        }
    }
}
