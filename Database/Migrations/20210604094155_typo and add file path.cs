using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class typoandaddfilepath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tag",
                table: "PhotoEntities",
                newName: "Tags");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePathFull",
                table: "PhotoEntities");

            migrationBuilder.DropColumn(
                name: "FilePathThumbnail",
                table: "PhotoEntities");

            migrationBuilder.RenameColumn(
                name: "Tags",
                table: "PhotoEntities",
                newName: "Tag");
        }
    }
}
