﻿// <auto-generated />
using System;
using BackEndAPI.Service.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackEndAPI.Service.Migrations
{
    [DbContext(typeof(ApiDBContext))]
    [Migration("20241009014000_SeedDatabase")]
    partial class SeedDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("BackEndAPI.Core.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bio")
                        .HasColumnType("TEXT");

                    b.Property<string>("Department")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Professors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bio = "Specializes in artificial intelligence and machine learning with over 20 years of research experience.",
                            Department = "Computer Science",
                            Email = "john.smith@university.edu",
                            Name = "Dr. John Smith"
                        },
                        new
                        {
                            Id = 2,
                            Bio = "Expert in quantum mechanics and particle physics, leading numerous research projects in theoretical physics.",
                            Department = "Physics",
                            Email = "jane.doe@university.edu",
                            Name = "Dr. Jane Doe"
                        },
                        new
                        {
                            Id = 3,
                            Bio = "Mathematical analysis and topology researcher, known for contributions to abstract algebra and number theory.",
                            Department = "Mathematics",
                            Email = "albert.johnson@university.edu",
                            Name = "Dr. Albert Johnson"
                        },
                        new
                        {
                            Id = 4,
                            Bio = "Researcher in molecular biology and genetics, with a focus on DNA sequencing and genome editing techniques.",
                            Department = "Biology",
                            Email = "emily.davis@university.edu",
                            Name = "Dr. Emily Davis"
                        });
                });

            modelBuilder.Entity("BackEndAPI.Core.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Developing an AI-based chatbot to assist with customer service automation for a leading e-commerce platform.",
                            EndDate = new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "AI-Powered Chatbot Development",
                            Type = "Research and Development"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Implementing an Internet of Things (IoT) infrastructure to monitor and optimize city-wide traffic and utilities management.",
                            EndDate = new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Smart City IoT Implementation",
                            Type = "Infrastructure"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Designing an e-learning platform for students to access virtual courses, complete assessments, and track progress.",
                            EndDate = new DateTime(2022, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "E-Learning Platform",
                            Type = "Software Development"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Developing a blockchain solution for securing and tracking the movement of goods across the supply chain.",
                            EndDate = new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Blockchain for Supply Chain",
                            Type = "Research and Development"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Creating a mobile application to allow users to track their health metrics and communicate with healthcare professionals.",
                            EndDate = new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Mobile Health App",
                            Type = "App Development"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Upgrading the cybersecurity system of a financial institution to ensure compliance with new data protection regulations.",
                            EndDate = new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Cybersecurity System Upgrade",
                            Type = "Security"
                        });
                });

            modelBuilder.Entity("BackEndAPI.Core.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("BackEndAPI.Core.Students", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bio")
                        .HasColumnType("TEXT");

                    b.Property<string>("Course")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Registration")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bio = "Enthusiastic student with a passion for software development and AI.",
                            Course = "Computer Science",
                            Email = "alice.johnson@example.com",
                            Name = "Alice Johnson",
                            Registration = "2023001"
                        },
                        new
                        {
                            Id = 2,
                            Bio = "Focused on embedded systems and renewable energy technologies.",
                            Course = "Electrical Engineering",
                            Email = "michael.smith@example.com",
                            Name = "Michael Smith",
                            Registration = "2023002"
                        },
                        new
                        {
                            Id = 3,
                            Bio = "Aiming to leverage technology for improving business operations.",
                            Course = "Business Administration",
                            Email = "sophia.brown@example.com",
                            Name = "Sophia Brown",
                            Registration = "2023003"
                        },
                        new
                        {
                            Id = 4,
                            Bio = "Keen interest in quantum mechanics and astrophysics.",
                            Course = "Physics",
                            Email = "james.wilson@example.com",
                            Name = "James Wilson",
                            Registration = "2023004"
                        },
                        new
                        {
                            Id = 5,
                            Bio = "Passionate about cybersecurity and network security.",
                            Course = "Information Technology",
                            Email = "emma.davis@example.com",
                            Name = "Emma Davis",
                            Registration = "2023005"
                        },
                        new
                        {
                            Id = 6,
                            Bio = "Aiming to extract valuable insights from data using machine learning.",
                            Course = "Data Science",
                            Email = "oliver.martinez@example.com",
                            Name = "Oliver Martinez",
                            Registration = "2023006"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
