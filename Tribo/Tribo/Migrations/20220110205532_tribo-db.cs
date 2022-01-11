using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tribo.Migrations
{
    public partial class tribodb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email_User",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email_User",
                table: "Cliente");
        }
    }
}
