using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackEndAPI.Service.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationshipProjectSkill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectSkill",
                columns: table => new
                {
                    ProjectsId = table.Column<int>(type: "INTEGER", nullable: false),
                    SkillsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSkill", x => new { x.ProjectsId, x.SkillsId });
                    table.ForeignKey(
                        name: "FK_ProjectSkill_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectSkill_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "A modern, object-oriented programming language developed by Microsoft.", "C#" },
                    { 2, "A framework for building web applications and services with .NET.", "ASP.NET" },
                    { 3, "A standard language for storing, manipulating, and retrieving data in databases.", "SQL" },
                    { 4, "A dynamic, high-level programming language commonly used for web development.", "JavaScript" },
                    { 5, "A JavaScript library for building user interfaces.", "React" },
                    { 6, "An object-relational mapper (ORM) for working with databases using .NET.", "Entity Framework" },
                    { 7, "Microsoft's cloud computing platform for building, testing, and deploying applications.", "Azure" },
                    { 8, "A distributed version control system for tracking changes in source code.", "Git" },
                    { 9, "A platform for developing, shipping, and running applications in containers.", "Docker" },
                    { 10, "A methodology for managing software development projects with iterative processes.", "Agile" }
                });

            migrationBuilder.InsertData(
                table: "ProjectSkill",
                columns: new[] { "ProjectsId", "SkillsId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 1, 5 },
                    { 3, 7 },
                    { 4, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSkill_SkillsId",
                table: "ProjectSkill",
                column: "SkillsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectSkill");

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
