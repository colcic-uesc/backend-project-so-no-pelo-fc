using System;
using BackEndAPI.Core;
using Microsoft.EntityFrameworkCore;

namespace BackEndAPI.Service.DataBase.Entities;

public class ApiDBContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Professor> Professors { get; set; }
    public DbSet<Skill> Skills { get; set; }

    public ApiDBContext(DbContextOptions<ApiDBContext> options)
        :base(options)
    {}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().HasKey(x => x.Id);
        modelBuilder.Entity<Professor>().HasKey(x => x.Id);
        modelBuilder.Entity<Project>().HasKey(x => x.Id);
        modelBuilder.Entity<Skill>().HasKey(x => x.Id);

        modelBuilder.Entity<Project>()
                    .HasMany(s => s.Skills)
                    .WithMany(p => p.Projects)
                    .UsingEntity(j => j.HasData(
                        new { ProjectsId = 1, SkillsId = 2 },
                        new { ProjectsId = 1, SkillsId = 5 },
                        new { ProjectsId = 3, SkillsId = 7 },
                        new { ProjectsId = 4, SkillsId = 4 }
                    ));
                    
        modelBuilder.SeedProfessors();
        modelBuilder.SeedStudents();
        modelBuilder.SeedProjects();
        modelBuilder.SeedSkills();
        //modelBuilder.SeedProjectSkill();
    }
}