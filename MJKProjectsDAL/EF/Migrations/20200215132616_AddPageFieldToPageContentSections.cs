using Microsoft.EntityFrameworkCore.Migrations;

namespace MJKProjectsDAL.EF.Migrations
{
    public partial class AddPageFieldToPageContentSections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "page_content_section_page",
                table: "page_content_sections",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "page_content_section_page",
                table: "page_content_sections");
        }
    }
}
