using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicUniverse.Persistence.Migrations
{
    public partial class images : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Artists");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Artists",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Format = table.Column<string>(nullable: true),
                    Content = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artists_ImageId",
                table: "Artists",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Images_ImageId",
                table: "Artists",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Images_ImageId",
                table: "Artists");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Artists_ImageId",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Artists");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Artists",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
