using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GorgesMusic.Data.Migrations
{
    public partial class ChangeSongTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Source",
                table: "Songs",
                newName: "AudioLink");

            migrationBuilder.AddColumn<string>(
                name: "CardImage",
                table: "Songs",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardImage",
                table: "Songs");

            migrationBuilder.RenameColumn(
                name: "AudioLink",
                table: "Songs",
                newName: "Source");
        }
    }
}
