using System;
using BackEndAPI.Core;
using Microsoft.EntityFrameworkCore;

namespace BackEndAPI.Service.DataBase.Entities;

public class ApiDBContext : DbContext
{
    public DbSet<Students> Students { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Professor> Professors { get; set; }
    public DbSet<Skill> Skills { get; set; }

    public ApiDBContext(DbContextOptions<ApiDBContext> options)
        :base(options)
    {}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Students>().HasKey(x => x.Id);
        modelBuilder.Entity<Professor>().HasKey(x => x.Id);
        modelBuilder.Entity<Project>().HasKey(x => x.Id);
        modelBuilder.Entity<Skill>().HasKey(x => x.Id);

        modelBuilder.SeedProfessors();
        modelBuilder.SeedProjects();
        modelBuilder.SeedStudents();
    }
}