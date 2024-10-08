using BackEndAPI.Core;
using Microsoft.EntityFrameworkCore;

namespace BackEndAPI.Service.DataBase;

public static class ModelBuilderExtensions
{
    public static void SeedProfessors(this ModelBuilder modelBuilder) 
    {
        modelBuilder.Entity<Professor>().HasData(
            new Professor
            {
                Id = 1,
                Name = "Dr. John Smith",
                Email = "john.smith@university.edu",
                Department = "Computer Science",
                Bio = "Specializes in artificial intelligence and machine learning with over 20 years of research experience."
            },
            new Professor
            {
                Id = 2,
                Name = "Dr. Jane Doe",
                Email = "jane.doe@university.edu",
                Department = "Physics",
                Bio = "Expert in quantum mechanics and particle physics, leading numerous research projects in theoretical physics."
            },
            new Professor
            {
                Id = 3,
                Name = "Dr. Albert Johnson",
                Email = "albert.johnson@university.edu",
                Department = "Mathematics",
                Bio = "Mathematical analysis and topology researcher, known for contributions to abstract algebra and number theory."
            },
            new Professor
            {
                Id = 4,
                Name = "Dr. Emily Davis",
                Email = "emily.davis@university.edu",
                Department = "Biology",
                Bio = "Researcher in molecular biology and genetics, with a focus on DNA sequencing and genome editing techniques."
            }
        );
    }

    public static void SeedProjects (this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>().HasData(
             new Project
            {
                Id = 1,
                Title = "AI-Powered Chatbot Development",
                Description = "Developing an AI-based chatbot to assist with customer service automation for a leading e-commerce platform.",
                Type = "Research and Development",
                StartDate = new DateTime(2023, 1, 15),
                EndDate = new DateTime(2024, 1, 15),
            },
            new Project
            {
                Id = 2,
                Title = "Smart City IoT Implementation",
                Description = "Implementing an Internet of Things (IoT) infrastructure to monitor and optimize city-wide traffic and utilities management.",
                Type = "Infrastructure",
                StartDate = new DateTime(2022, 5, 10),
                EndDate = new DateTime(2023, 11, 25)
            },
            new Project
            {
                Id = 3,
                Title = "E-Learning Platform",
                Description = "Designing an e-learning platform for students to access virtual courses, complete assessments, and track progress.",
                Type = "Software Development",
                StartDate = new DateTime(2021, 9, 1),
                EndDate = new DateTime(2022, 6, 15)
            },
            new Project
            {
                Id = 4,
                Title = "Blockchain for Supply Chain",
                Description = "Developing a blockchain solution for securing and tracking the movement of goods across the supply chain.",
                Type = "Research and Development",
                StartDate = new DateTime(2023, 3, 20),
                EndDate = new DateTime(2024, 4, 30),
                
            },
            new Project
            {
                Id = 5,
                Title = "Mobile Health App",
                Description = "Creating a mobile application to allow users to track their health metrics and communicate with healthcare professionals.",
                Type = "App Development",
                StartDate = new DateTime(2022, 2, 1),
                EndDate = new DateTime(2023, 7, 20)
            },
            new Project
            {
                Id = 6,
                Title = "Cybersecurity System Upgrade",
                Description = "Upgrading the cybersecurity system of a financial institution to ensure compliance with new data protection regulations.",
                Type = "Security",
                StartDate = new DateTime(2023, 6, 1),
                EndDate = new DateTime(2024, 5, 15)
            }
        );
    }

    public static void SeedStudents(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().HasData(
            new Student
            {
                Id = 1,
                Registration = "2023001",
                Name = "Alice Johnson",
                Email = "alice.johnson@example.com",
                Course = "Computer Science",
                Bio = "Enthusiastic student with a passion for software development and AI."
            },
            new Student
            {
                Id = 2,
                Registration = "2023002",
                Name = "Michael Smith",
                Email = "michael.smith@example.com",
                Course = "Electrical Engineering",
                Bio = "Focused on embedded systems and renewable energy technologies."
            },
            new Student
            {
                Id = 3,
                Registration = "2023003",
                Name = "Sophia Brown",
                Email = "sophia.brown@example.com",
                Course = "Business Administration",
                Bio = "Aiming to leverage technology for improving business operations."
            },
            new Student
            {
                Id = 4,
                Registration = "2023004",
                Name = "James Wilson",
                Email = "james.wilson@example.com",
                Course = "Physics",
                Bio = "Keen interest in quantum mechanics and astrophysics."
            },
            new Student
            {
                Id = 5,
                Registration = "2023005",
                Name = "Emma Davis",
                Email = "emma.davis@example.com",
                Course = "Information Technology",
                Bio = "Passionate about cybersecurity and network security."
            },
            new Student
            {
                Id = 6,
                Registration = "2023006",
                Name = "Oliver Martinez",
                Email = "oliver.martinez@example.com",
                Course = "Data Science",
                Bio = "Aiming to extract valuable insights from data using machine learning."
            }
        );
    }

    public static void SeedSkills(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Skill>()
                    .HasData(
                        new Skill 
                        { 
                            Id = 1,
                            Title = "C#",
                            Description = "A modern, object-oriented programming language developed by Microsoft."
                        },
                        new Skill 
                        { 
                            Id = 2,
                            Title = "ASP.NET",
                            Description = "A framework for building web applications and services with .NET." 
                        },
                        new Skill 
                        { 
                            Id = 3,
                            Title = "SQL",
                            Description = "A standard language for storing, manipulating, and retrieving data in databases." 
                        },
                        new Skill 
                        { 
                            Id = 4,
                            Title = "JavaScript",
                            Description = "A dynamic, high-level programming language commonly used for web development." 
                        },
                        new Skill 
                        { 
                            Id = 5,
                            Title = "React",
                            Description = "A JavaScript library for building user interfaces." 
                        },
                        new Skill 
                        { 
                            Id = 6,
                            Title = "Entity Framework",
                            Description = "An object-relational mapper (ORM) for working with databases using .NET." 
                        },
                        new Skill 
                        { 
                            Id = 7,
                            Title = "Azure",
                            Description = "Microsoft's cloud computing platform for building, testing, and deploying applications." 
                        },
                        new Skill 
                        { 
                            Id = 8,
                            Title = "Git",
                            Description = "A distributed version control system for tracking changes in source code." 
                        },
                        new Skill 
                        { 
                            Id = 9,
                            Title = "Docker",
                            Description = "A platform for developing, shipping, and running applications in containers." 
                        },
                        new Skill 
                        { 
                            Id = 10,
                            Title = "Agile",
                            Description = "A methodology for managing software development projects with iterative processes." 
                        }
                    );
    }

   /* public static void SeedProjectSkill (this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>()
                    .HasMany(s => s.Skills)
                    .WithMany(p => p.Projects)
                    .UsingEntity(j => j.HasData(
                        new { ProjectsId = 1, SkillsId = 2 },
                        new { ProjectsId = 1, SkillsId = 5 },
                        new { ProjectsId = 3, SkillsId = 7 },
                        new { ProjectsId = 4, SkillsId = 4 }
                    ));
    }*/
}