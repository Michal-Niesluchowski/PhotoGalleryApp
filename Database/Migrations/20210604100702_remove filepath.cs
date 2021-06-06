using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class removefilepath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePathFull",
                table: "PhotoEntities");

            migrationBuilder.DropColumn(
                name: "FilePathThumbnail",
                table: "PhotoEntities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePathFull",
                table: "PhotoEntities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilePathThumbnail",
                table: "PhotoEntities",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
