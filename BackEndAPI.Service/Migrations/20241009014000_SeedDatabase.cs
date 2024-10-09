using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackEndAPI.Service.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Professors",
                columns: new[] { "Id", "Bio", "Department", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "Specializes in artificial intelligence and machine learning with over 20 years of research experience.", "Computer Science", "john.smith@university.edu", "Dr. John Smith" },
                    { 2, "Expert in quantum mechanics and particle physics, leading numerous research projects in theoretical physics.", "Physics", "jane.doe@university.edu", "Dr. Jane Doe" },
                    { 3, "Mathematical analysis and topology researcher, known for contributions to abstract algebra and number theory.", "Mathematics", "albert.johnson@university.edu", "Dr. Albert Johnson" },
                    { 4, "Researcher in molecular biology and genetics, with a focus on DNA sequencing and genome editing techniques.", "Biology", "emily.davis@university.edu", "Dr. Emily Davis" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "EndDate", "StartDate", "Title", "Type" },
                values: new object[,]
                {
                    { 1, "Developing an AI-based chatbot to assist with customer service automation for a leading e-commerce platform.", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "AI-Powered Chatbot Development", "Research and Development" },
                    { 2, "Implementing an Internet of Things (IoT) infrastructure to monitor and optimize city-wide traffic and utilities management.", new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smart City IoT Implementation", "Infrastructure" },
                    { 3, "Designing an e-learning platform for students to access virtual courses, complete assessments, and track progress.", new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "E-Learning Platform", "Software Development" },
                    { 4, "Developing a blockchain solution for securing and tracking the movement of goods across the supply chain.", new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blockchain for Supply Chain", "Research and Development" },
                    { 5, "Creating a mobile application to allow users to track their health metrics and communicate with healthcare professionals.", new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobile Health App", "App Development" },
                    { 6, "Upgrading the cybersecurity system of a financial institution to ensure compliance with new data protection regulations.", new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cybersecurity System Upgrade", "Security" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Bio", "Course", "Email", "Name", "Registration" },
                values: new object[,]
                {
                    { 1, "Enthusiastic student with a passion for software development and AI.", "Computer Science", "alice.johnson@example.com", "Alice Johnson", "2023001" },
                    { 2, "Focused on embedded systems and renewable energy technologies.", "Electrical Engineering", "michael.smith@example.com", "Michael Smith", "2023002" },
                    { 3, "Aiming to leverage technology for improving business operations.", "Business Administration", "sophia.brown@example.com", "Sophia Brown", "2023003" },
                    { 4, "Keen interest in quantum mechanics and astrophysics.", "Physics", "james.wilson@example.com", "James Wilson", "2023004" },
                    { 5, "Passionate about cybersecurity and network security.", "Information Technology", "emma.davis@example.com", "Emma Davis", "2023005" },
                    { 6, "Aiming to extract valuable insights from data using machine learning.", "Data Science", "oliver.martinez@example.com", "Oliver Martinez", "2023006" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Professors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

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
        }
    }
}
