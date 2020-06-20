using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicUniverse.Persistence.Migrations
{
    public partial class artist_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Artists_CountryId",
                table: "Artists",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Countries_CountryId",
                table: "Artists",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Countries_CountryId",
                table: "Artists");

            migrationBuilder.DropIndex(
                name: "IX_Artists_CountryId",
                table: "Artists");
        }
    }
}
