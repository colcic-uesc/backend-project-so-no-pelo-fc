using System;
using BackEndAPI.Core;
using BackEndAPI.Service.DataBase.Interfaces;


namespace BackEndAPI.Service.DataBase.Entities;

public class ProjectCRUD : IProjectCRUD
{   
    private readonly ApiDBContext _context;
    public ProjectCRUD(ApiDBContext context)
    {
        _context = context;
    }

    public void Create(Project entity)
    {
        _context.Projects.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var project = _context.Projects.Find(id) ?? throw new Exception("Project not found");
        _context.Projects.Remove(project);
        _context.SaveChanges();
    }

    public IEnumerable<Project> GetAll()
    {
        return _context.Projects;
    }

    public Project? GetById(int id)
    {
        var project = _context.Projects.Find(id) ?? throw new Exception("Project not found");
        return project;
    }

    public void Update(Project entity)
    {
        var project = _context.Projects.Find(entity.Id) ?? throw new Exception("Project not found");
        project.Title = entity.Title;
        project.Description = entity.Description;
        project.Type = entity.Type;
        project.StartDate = entity.StartDate;
        project.EndDate = entity.EndDate;
        _context.SaveChanges();
    }
}