using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GorgesMusic.Data.Migrations
{
    /// <inheritdoc />
    public partial class RestoreDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e971f0f-e497-4172-bcf0-89a45e88d22e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b8813563-48e7-4b5d-bd5f-6635c0c1abdd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "440a926a-ecd9-4039-9f76-11439bdb29ad", null, "Administrator", "ADMINISTRATOR" },
                    { "b21621bc-8203-48e9-a1f5-4a993848cfc3", null, "Viewer", "VIEWER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "440a926a-ecd9-4039-9f76-11439bdb29ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b21621bc-8203-48e9-a1f5-4a993848cfc3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6e971f0f-e497-4172-bcf0-89a45e88d22e", "77dfd6a5-047b-407c-ae35-796053737ec2", "Administrator", "ADMINISTRATOR" },
                    { "b8813563-48e7-4b5d-bd5f-6635c0c1abdd", "587188fb-632d-4099-bba4-1b2eb226dd97", "Viewer", "VIEWER" }
                });
        }
    }
}
