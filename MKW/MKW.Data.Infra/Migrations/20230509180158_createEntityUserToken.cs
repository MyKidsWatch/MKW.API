using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MKW.Data.Context.Migrations
{
    public partial class createEntityUserToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_MKW_USER_TOKEN",
                columns: table => new
                {
                    USER_ID = table.Column<int>(type: "int", nullable: false),
                    KEY_CODE = table.Column<int>(type: "int", nullable: false),
                    TOKEN = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MKW_USER_TOKEN", x => new { x.USER_ID, x.KEY_CODE });
                    table.ForeignKey(
                        name: "FK_TB_MKW_USER_TOKEN_AspNetUsers_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_MKW_USER_TOKEN");
        }
    }
}
