using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEndAPI.Service.Migrations
{
    /// <inheritdoc />
    public partial class RemovingRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Students_StudentsId",
                table: "Skills");

            migrationBuilder.DropTable(
                name: "ProjectSkill");

            migrationBuilder.DropIndex(
                name: "IX_Skills_StudentsId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "StudentsId",
                table: "Skills");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentsId",
                table: "Skills",
                type: "INTEGER",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Skills_StudentsId",
                table: "Skills",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSkill_SkillsId",
                table: "ProjectSkill",
                column: "SkillsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Students_StudentsId",
                table: "Skills",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
