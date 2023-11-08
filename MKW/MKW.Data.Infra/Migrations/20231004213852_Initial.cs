using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MKW.Data.Context.Migrations
{
    public partial class Initial : Migration
    {
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
                name: "TB_RPR_REASON",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TITLE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ALTER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RPR_REASON", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_RPR_STATUS",
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
                    table.PrimaryKey("PK_TB_RPR_STATUS", x => x.ID);
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
                name: "TB_USR_ROLES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USR_ROLES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_USR_USERS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USR_USERS", x => x.Id);
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
                name: "TB_USR_ROLE_CLAIM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USR_ROLE_CLAIM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_USR_ROLE_CLAIM_TB_USR_ROLES_RoleId",
                        column: x => x.RoleId,
                        principalTable: "TB_USR_ROLES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_USR_PERSON",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IMAGE_URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BIRTHDATE = table.Column<DateTime>(type: "date", nullable: false),
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    GENDER_ID = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<int>(type: "int", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_TB_USR_PERSON_TB_USR_USERS_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "TB_USR_USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_USR_USER_CLAIM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USR_USER_CLAIM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_USR_USER_CLAIM_TB_USR_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "TB_USR_USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_USR_USER_KEYCODE",
                columns: table => new
                {
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    KEY_CODE = table.Column<int>(type: "int", nullable: false),
                    TOKEN = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USR_USER_KEYCODE", x => new { x.USER_ID, x.KEY_CODE });
                    table.ForeignKey(
                        name: "FK_TB_USR_USER_KEYCODE_TB_USR_USERS_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "TB_USR_USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_USR_USER_LOGIN",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USR_USER_LOGIN", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_TB_USR_USER_LOGIN_TB_USR_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "TB_USR_USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_USR_USER_ROLE",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USR_USER_ROLE", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_TB_USR_USER_ROLE_TB_USR_ROLES_RoleId",
                        column: x => x.RoleId,
                        principalTable: "TB_USR_ROLES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_USR_USER_ROLE_TB_USR_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "TB_USR_USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_USR_USER_TOKEN",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USR_USER_TOKEN", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_TB_USR_USER_TOKEN_TB_USR_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "TB_USR_USERS",
                        principalColumn: "Id",
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
                    EXTERNAL_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    POST_ID = table.Column<int>(type: "int", nullable: true),
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
                        principalColumn: "ID");
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
                    STARS = table.Column<int>(type: "int", nullable: false),
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
                name: "TB_RPR_REPORT",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    REASON_ID = table.Column<int>(type: "int", nullable: false),
                    STATUS_ID = table.Column<int>(type: "int", nullable: false),
                    PERSON_ID = table.Column<int>(type: "int", nullable: false),
                    REVIEW_ID = table.Column<int>(type: "int", nullable: true),
                    COMMENT_ID = table.Column<int>(type: "int", nullable: true),
                    DETAILS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ALTER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ACTIVE = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_RPR_REPORT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_RPR_REPORT_TB_RPR_REASON_REASON_ID",
                        column: x => x.REASON_ID,
                        principalTable: "TB_RPR_REASON",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_RPR_REPORT_TB_RPR_STATUS_STATUS_ID",
                        column: x => x.STATUS_ID,
                        principalTable: "TB_RPR_STATUS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_RPR_REPORT_TB_RVW_COMMENT_COMMENT_ID",
                        column: x => x.COMMENT_ID,
                        principalTable: "TB_RVW_COMMENT",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TB_RPR_REPORT_TB_RVW_REVIEW_REVIEW_ID",
                        column: x => x.REVIEW_ID,
                        principalTable: "TB_RVW_REVIEW",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TB_RPR_REPORT_TB_USR_PERSON_PERSON_ID",
                        column: x => x.PERSON_ID,
                        principalTable: "TB_USR_PERSON",
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

            migrationBuilder.InsertData(
                table: "TB_MKW_PLATFORM",
                columns: new[] { "ID", "ACTIVE", "ALTER_DATE", "CREATE_DATE", "NAME", "UUID", "URL" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2023, 10, 4, 18, 38, 52, 360, DateTimeKind.Local).AddTicks(4514), "TMDb", new Guid("deb123ba-6f03-459f-b3ae-120ccc2c51cc"), "https://api.themoviedb.org/3" },
                    { 2, true, null, new DateTime(2023, 10, 4, 18, 38, 52, 360, DateTimeKind.Local).AddTicks(4519), "YouTube", new Guid("704de8e5-3a39-4510-86e3-5b517d2fd1fc"), "https://www.googleapis.com/youtube/v3" },
                    { 3, true, null, new DateTime(2023, 10, 4, 18, 38, 52, 360, DateTimeKind.Local).AddTicks(4529), "TikTok", new Guid("1da02678-c633-4177-890d-8086534694f9"), "" }
                });

            migrationBuilder.InsertData(
                table: "TB_RPR_REASON",
                columns: new[] { "ID", "ACTIVE", "ALTER_DATE", "CREATE_DATE", "DESCRIPTION", "TITLE", "UUID" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2023, 10, 4, 18, 38, 52, 361, DateTimeKind.Local).AddTicks(5506), "Abusive or threatening speech or writing that expresses prejudice on the basis of ethnicity, religion, sexual orientation, or similar grounds.", "Hate Speech", new Guid("5cfdf859-e25a-4b57-ac97-c43786813fb3") },
                    { 2, true, null, new DateTime(2023, 10, 4, 18, 38, 52, 361, DateTimeKind.Local).AddTicks(5511), "Aggressive pressure or intimidation against an individual or group.", "Harassment", new Guid("342391e9-4fb4-476b-b5bb-a3eb70e1c101") },
                    { 3, true, null, new DateTime(2023, 10, 4, 18, 38, 52, 361, DateTimeKind.Local).AddTicks(5513), "Material depicting sexual behavior. The sexual behavior involved may be explicit, implicit sexual behavior such as flirting, or include sexual language and euphemisms.", "Sexual Content", new Guid("2b6ecc27-9a27-4b9b-90ca-6afc482ce518") },
                    { 4, true, null, new DateTime(2023, 10, 4, 18, 38, 52, 361, DateTimeKind.Local).AddTicks(5515), "Other reasons. Please provide more information.", "Others", new Guid("6ef25a99-ffc7-4024-b330-507ec23dc4ee") }
                });

            migrationBuilder.InsertData(
                table: "TB_RPR_STATUS",
                columns: new[] { "ID", "ACTIVE", "ALTER_DATE", "CREATE_DATE", "NAME", "UUID" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2023, 10, 4, 18, 38, 52, 361, DateTimeKind.Local).AddTicks(6787), "Análise Pendente", new Guid("92dee59e-b75c-4b69-ace4-c4fecfcc723b") },
                    { 2, true, null, new DateTime(2023, 10, 4, 18, 38, 52, 361, DateTimeKind.Local).AddTicks(6791), "Analisado", new Guid("f8cc3fe7-d6b7-4eb7-955c-d0eae168c559") },
                    { 3, true, null, new DateTime(2023, 10, 4, 18, 38, 52, 361, DateTimeKind.Local).AddTicks(6794), "Descartado", new Guid("d6f3dd38-eadc-421e-a565-1261949b42db") }
                });

            migrationBuilder.InsertData(
                table: "TB_USR_GENDER",
                columns: new[] { "ID", "ACTIVE", "ALTER_DATE", "CREATE_DATE", "IS_BINARY", "NAME", "UUID" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 10, 4, 18, 38, 52, 358, DateTimeKind.Local).AddTicks(8739), new DateTime(2023, 10, 4, 18, 38, 52, 358, DateTimeKind.Local).AddTicks(8736), true, "Masculino", new Guid("db19ca43-dcca-4e17-8168-229fe5c140b4") },
                    { 2, true, new DateTime(2023, 10, 4, 18, 38, 52, 358, DateTimeKind.Local).AddTicks(8760), new DateTime(2023, 10, 4, 18, 38, 52, 358, DateTimeKind.Local).AddTicks(8759), true, "Feminino", new Guid("bb653181-9caa-4638-b5f3-aa85d3ac61f7") },
                    { 3, true, new DateTime(2023, 10, 4, 18, 38, 52, 358, DateTimeKind.Local).AddTicks(8762), new DateTime(2023, 10, 4, 18, 38, 52, 358, DateTimeKind.Local).AddTicks(8762), false, "Não Binário", new Guid("0446622e-2074-4e55-94a4-cb5898effb23") }
                });

            migrationBuilder.InsertData(
                table: "TB_USR_ROLES",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 11111, "0eb384ad-84c2-4f79-9627-3811ee475043", "admin", "ADMIN" },
                    { 11112, "aecb8ed1-331b-4fd6-8b93-3b3ddd37a55e", "standard", "STANDARD" }
                });

            migrationBuilder.InsertData(
                table: "TB_USR_USERS",
                columns: new[] { "Id", "AccessFailedCount", "Active", "AlterDate", "ConcurrencyStamp", "CreateDate", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 11111, 0, true, null, "33fb90be-9a32-4482-83ad-a89e221a7fca", new DateTime(2023, 10, 4, 18, 38, 52, 350, DateTimeKind.Local).AddTicks(1642), "projeto.mkw@gmail.com", true, "Administrador", "MyKidsWatch", false, null, "PROJETO.MWK@GMAIL.COM", "ADMIN11111", "AQAAAAEAACcQAAAAEG/S7DGT8O1G/IfnhIw3fnQADTan+vVg9p0aOMyrms83IAUlav/XRNAhspGQPyOlMg==", "5511978019550", true, "db3cb584-8182-40a4-968a-bed3b23e3313", false, "admin11111" });

            migrationBuilder.InsertData(
                table: "TB_MKW_PLATFORM_CATEGORY",
                columns: new[] { "ID", "ACTIVE", "ALTER_DATE", "CREATE_DATE", "NAME", "PLATFORM_ID", "UUID" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2023, 10, 4, 18, 38, 52, 360, DateTimeKind.Local).AddTicks(6241), "Filme", 1, new Guid("856def35-dc43-48b7-9add-9311ab164a15") },
                    { 2, true, null, new DateTime(2023, 10, 4, 18, 38, 52, 360, DateTimeKind.Local).AddTicks(6251), "Filme", 2, new Guid("0a32fd7f-2436-46d4-95e7-290f612ddcb0") },
                    { 3, true, null, new DateTime(2023, 10, 4, 18, 38, 52, 360, DateTimeKind.Local).AddTicks(6253), "Perfil", 3, new Guid("903e28a0-f37f-494f-b06c-d8d1d53dc7b4") }
                });

            migrationBuilder.InsertData(
                table: "TB_USR_USER_ROLE",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 11111, 11111 });

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
                name: "IX_TB_RPR_REPORT_COMMENT_ID",
                table: "TB_RPR_REPORT",
                column: "COMMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RPR_REPORT_PERSON_ID",
                table: "TB_RPR_REPORT",
                column: "PERSON_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RPR_REPORT_REASON_ID",
                table: "TB_RPR_REPORT",
                column: "REASON_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RPR_REPORT_REVIEW_ID",
                table: "TB_RPR_REPORT",
                column: "REVIEW_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_RPR_REPORT_STATUS_ID",
                table: "TB_RPR_REPORT",
                column: "STATUS_ID");

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
                name: "IX_TB_USR_OPERATION_OPERATION_TYPE_ID",
                table: "TB_USR_OPERATION",
                column: "OPERATION_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USR_OPERATION_PERSON_ID",
                table: "TB_USR_OPERATION",
                column: "PERSON_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USR_PERSON_GENDER_ID",
                table: "TB_USR_PERSON",
                column: "GENDER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USR_PERSON_USER_ID",
                table: "TB_USR_PERSON",
                column: "USER_ID");

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
                name: "IX_TB_USR_ROLE_CLAIM_RoleId",
                table: "TB_USR_ROLE_CLAIM",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "TB_USR_ROLES",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USR_USER_CLAIM_UserId",
                table: "TB_USR_USER_CLAIM",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USR_USER_LOGIN_UserId",
                table: "TB_USR_USER_LOGIN",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USR_USER_ROLE_RoleId",
                table: "TB_USR_USER_ROLE",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "TB_USR_USERS",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "TB_USR_USERS",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_MKW_CONTENT_GENRE");

            migrationBuilder.DropTable(
                name: "TB_PRM_PREMIUM_PERSON");

            migrationBuilder.DropTable(
                name: "TB_RPR_REPORT");

            migrationBuilder.DropTable(
                name: "TB_RVW_AWARD_PERSON");

            migrationBuilder.DropTable(
                name: "TB_RVW_COMMENT_DETAILS");

            migrationBuilder.DropTable(
                name: "TB_RVW_REVIEW_DETAILS");

            migrationBuilder.DropTable(
                name: "TB_USR_OPERATION");

            migrationBuilder.DropTable(
                name: "TB_USR_PERSON_CHILD");

            migrationBuilder.DropTable(
                name: "TB_USR_ROLE_CLAIM");

            migrationBuilder.DropTable(
                name: "TB_USR_USER_CLAIM");

            migrationBuilder.DropTable(
                name: "TB_USR_USER_KEYCODE");

            migrationBuilder.DropTable(
                name: "TB_USR_USER_LOGIN");

            migrationBuilder.DropTable(
                name: "TB_USR_USER_ROLE");

            migrationBuilder.DropTable(
                name: "TB_USR_USER_TOKEN");

            migrationBuilder.DropTable(
                name: "TB_MKW_GENRE");

            migrationBuilder.DropTable(
                name: "TB_PRM_TIER_PLAN");

            migrationBuilder.DropTable(
                name: "TB_RPR_REASON");

            migrationBuilder.DropTable(
                name: "TB_RPR_STATUS");

            migrationBuilder.DropTable(
                name: "TB_RVW_AWARD");

            migrationBuilder.DropTable(
                name: "TB_RVW_COMMENT");

            migrationBuilder.DropTable(
                name: "TB_USR_OPERATION_TYPE");

            migrationBuilder.DropTable(
                name: "TB_USR_AGE_RANGE");

            migrationBuilder.DropTable(
                name: "TB_USR_ROLES");

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
                name: "TB_USR_USERS");

            migrationBuilder.DropTable(
                name: "TB_MKW_PLATFORM");
        }
    }
}
