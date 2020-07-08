using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MJKProjectsDAL.EF.Migrations
{
    public partial class ExtraModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "educations",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    education_name = table.Column<string>(nullable: false),
                    education_complete = table.Column<bool>(nullable: false),
                    education_from = table.Column<DateTime>(nullable: false),
                    education_till = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_educations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "skills",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    skill_name = table.Column<string>(nullable: false),
                    skill_rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skills", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "work_histories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    work_history_employer = table.Column<string>(nullable: false),
                    work_history_from = table.Column<DateTime>(nullable: false),
                    work_history_till = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_work_histories", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_educations_education_name",
                table: "educations",
                column: "education_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_skills_skill_name",
                table: "skills",
                column: "skill_name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "educations");

            migrationBuilder.DropTable(
                name: "skills");

            migrationBuilder.DropTable(
                name: "work_histories");
        }
    }
}
