using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleFileUpload.Migrations
{
    public partial class AddFileConentColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Bytes",
                table: "FileContents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bytes",
                table: "FileContents");
        }
    }
}
