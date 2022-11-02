using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GorgesMusic.Data.Migrations
{
    public partial class ChangePropertyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistSong_Songs_ArtistsId1",
                table: "ArtistSong");

            migrationBuilder.RenameColumn(
                name: "ArtistsId1",
                table: "ArtistSong",
                newName: "SongsId");

            migrationBuilder.RenameIndex(
                name: "IX_ArtistSong_ArtistsId1",
                table: "ArtistSong",
                newName: "IX_ArtistSong_SongsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistSong_Songs_SongsId",
                table: "ArtistSong",
                column: "SongsId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtistSong_Songs_SongsId",
                table: "ArtistSong");

            migrationBuilder.RenameColumn(
                name: "SongsId",
                table: "ArtistSong",
                newName: "ArtistsId1");

            migrationBuilder.RenameIndex(
                name: "IX_ArtistSong_SongsId",
                table: "ArtistSong",
                newName: "IX_ArtistSong_ArtistsId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtistSong_Songs_ArtistsId1",
                table: "ArtistSong",
                column: "ArtistsId1",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
