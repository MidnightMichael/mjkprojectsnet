using Microsoft.EntityFrameworkCore.Migrations;

namespace MJKProjectsDAL.EF.Migrations
{
    public partial class AddedSlugsToProjectsBlogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "project_post_slug",
                table: "projects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "blog_post_slug",
                table: "blog_posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "project_post_slug",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "blog_post_slug",
                table: "blog_posts");
        }
    }
}
