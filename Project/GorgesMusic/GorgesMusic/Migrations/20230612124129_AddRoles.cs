using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GorgesMusic.Data.Migrations
{
    public partial class AddRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Songs",
                type: "character varying(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6e971f0f-e497-4172-bcf0-89a45e88d22e", "77dfd6a5-047b-407c-ae35-796053737ec2", "Administrator", "ADMINISTRATOR" },
                    { "b8813563-48e7-4b5d-bd5f-6635c0c1abdd", "587188fb-632d-4099-bba4-1b2eb226dd97", "Viewer", "VIEWER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e971f0f-e497-4172-bcf0-89a45e88d22e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8813563-48e7-4b5d-bd5f-6635c0c1abdd");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Songs",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(80)",
                oldMaxLength: 80);
        }
    }
}
