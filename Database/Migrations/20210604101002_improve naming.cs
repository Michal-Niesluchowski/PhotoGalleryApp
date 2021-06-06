using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class improvenaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "PhotoEntities",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "PhotoEntities",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "PhotoEntities",
                newName: "FileName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "PhotoEntities",
                newName: "Comment");
        }
    }
}
