using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackEndAPI.Service.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationshipUserProfessor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Students",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Professors",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Bio", "Email", "Name", "Registration", "UserId" },
                values: new object[] { "Enthusiastic student with a passion for software development and girls with daddy issues.", "valter@example.com", "Vitor Pires Rocha", "2021001", 1 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Course", "Email", "Name", "Registration", "UserId" },
                values: new object[] { "Computer Science", "luizinho@example.com", "Luiz Palhacadas", "2021002", 2 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Course", "Email", "Name", "Registration", "UserId" },
                values: new object[] { "Computer Science", "coitinho@example.com", "Vitor Coito", "2021003", 3 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Rules", "Username" },
                values: new object[,]
                {
                    { 1, "xota", "student", "Valter Delas" },
                    { 2, "adm", "student", "Luiz Palhacadas" },
                    { 3, "batata", "student", "Coito" },
                    { 4, "sim", "prof", "Smith" },
                    { 5, "sim", "prof", "Doe" },
                    { 6, "sim", "prof", "Albert" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Professors_UserId",
                table: "Professors",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Professors_Users_UserId",
                table: "Professors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_UserId",
                table: "Students",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professors_Users_UserId",
                table: "Professors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_UserId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_UserId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Professors_UserId",
                table: "Professors");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Professors");

            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "Bio", "Department", "Email", "Name" },
                values: new object[] { 4, "Researcher in molecular biology and genetics, with a focus on DNA sequencing and genome editing techniques.", "Biology", "emily.davis@university.edu", "Dr. Emily Davis" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Bio", "Email", "Name", "Registration" },
                values: new object[] { "Enthusiastic student with a passion for software development and AI.", "alice.johnson@example.com", "Alice Johnson", "2023001" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Course", "Email", "Name", "Registration" },
                values: new object[] { "Electrical Engineering", "michael.smith@example.com", "Michael Smith", "2023002" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Course", "Email", "Name", "Registration" },
                values: new object[] { "Business Administration", "sophia.brown@example.com", "Sophia Brown", "2023003" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Bio", "Course", "Email", "Name", "Registration" },
                values: new object[,]
                {
                    { 4, "Keen interest in quantum mechanics and astrophysics.", "Physics", "james.wilson@example.com", "James Wilson", "2023004" },
                    { 5, "Passionate about cybersecurity and network security.", "Information Technology", "emma.davis@example.com", "Emma Davis", "2023005" },
                    { 6, "Aiming to extract valuable insights from data using machine learning.", "Data Science", "oliver.martinez@example.com", "Oliver Martinez", "2023006" }
                });
        }
    }
}
