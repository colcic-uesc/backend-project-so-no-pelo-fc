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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Students>().HasKey(x => x.Id);
        modelBuilder.Entity<Professor>().HasKey(x => x.Id);
        modelBuilder.Entity<Project>().HasKey(x => x.Id);
        modelBuilder.Entity<Skill>().HasKey(x => x.Id);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=C:/Users/Vitor/OneDrive/Documentos/ProjetoWeb/backend-project-so-no-pelo-fc/BackEndAPI/ShowRoomDB.db");
    }
}