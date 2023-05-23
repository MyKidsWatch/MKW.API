using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MKW.Data.Context.Migrations
{
    public partial class newEntities : Migration
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

            migrationBuilder.InsertData(
                table: "TB_USR_GENDER",
                columns: new[] { "ID", "ACTIVE", "ALTER_DATE", "CREATE_DATE", "IS_BINARY", "NAME", "UUID" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 5, 20, 21, 44, 40, 781, DateTimeKind.Local).AddTicks(5929), new DateTime(2023, 5, 20, 21, 44, 40, 781, DateTimeKind.Local).AddTicks(5918), true, "Masculino", new Guid("f302123a-82b0-47fa-8d86-817b9c6513e4") },
                    { 2, true, new DateTime(2023, 5, 20, 21, 44, 40, 781, DateTimeKind.Local).AddTicks(5934), new DateTime(2023, 5, 20, 21, 44, 40, 781, DateTimeKind.Local).AddTicks(5933), true, "Feminino", new Guid("6f5fb446-d753-4f0a-a087-134ca9cca8e1") },
                    { 3, true, new DateTime(2023, 5, 20, 21, 44, 40, 781, DateTimeKind.Local).AddTicks(5936), new DateTime(2023, 5, 20, 21, 44, 40, 781, DateTimeKind.Local).AddTicks(5935), false, "Não Binário", new Guid("9f7afae3-4027-4c5e-973f-8b1598ed944e") }
                });

            migrationBuilder.InsertData(
                table: "TB_USR_ROLES",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 11111, "1e078ba4-e954-487a-b5c2-cfcd1eb416d9", "admin", "ADMIN" },
                    { 11112, "2f46661b-35b5-4fb2-b5f2-da27e2d89750", "standard", "STANDARD" }
                });

            migrationBuilder.InsertData(
                table: "TB_USR_USERS",
                columns: new[] { "Id", "AccessFailedCount", "Active", "AlterDate", "ConcurrencyStamp", "CreateDate", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 11111, 0, true, null, "f16da048-23d4-44a8-9cf4-b8c1318269ce", new DateTime(2023, 5, 20, 21, 44, 40, 772, DateTimeKind.Local).AddTicks(7648), "projeto.mkw@gmail.com", true, "Administrador", "MyKidsWatch", false, null, "PROJETO.MWK@GMAIL.COM", "ADMIN11111", "AQAAAAEAACcQAAAAEMyG4vtnXB8Sq2ScI6tU6aetDV/ztN7QSmszXIa9FqY4F6lJoFVRdCblG1SLb2u9sA==", "5511978019550", true, "cfd69d2f-377e-44f2-a08d-da595d6b3a5f", false, "admin11111" });

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
