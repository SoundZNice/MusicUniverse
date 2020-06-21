using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicUniverse.Persistence.Migrations
{
    public partial class composition_albumv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageId = table.Column<int>(nullable: true),
                    ArtistId = table.Column<int>(nullable: true),
                    ArtistId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Artists_ArtistId1",
                        column: x => x.ArtistId1,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Albums_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Compositions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ArtistId = table.Column<int>(nullable: true),
                    AlbumId = table.Column<int>(nullable: true),
                    ImageId = table.Column<int>(nullable: true),
                    ReleaseDate = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    Lyrics = table.Column<string>(nullable: true),
                    ArtistId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compositions_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Compositions_Artists_ArtistId1",
                        column: x => x.ArtistId1,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Compositions_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistId1",
                table: "Albums",
                column: "ArtistId1");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ImageId",
                table: "Albums",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Compositions_AlbumId",
                table: "Compositions",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Compositions_ArtistId1",
                table: "Compositions",
                column: "ArtistId1");

            migrationBuilder.CreateIndex(
                name: "IX_Compositions_ImageId",
                table: "Compositions",
                column: "ImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compositions");

            migrationBuilder.DropTable(
                name: "Albums");
        }
    }
}
