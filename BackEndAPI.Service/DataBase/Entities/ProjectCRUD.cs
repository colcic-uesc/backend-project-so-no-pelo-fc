using System;
using BackEndAPI.Core;
using BackEndAPI.Service.DataBase.Interfaces;
using Microsoft.EntityFrameworkCore;


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

    public Project? CreateRelationship(int pId, int sId)
    {
        var project = _context.Projects.Find(pId) ?? throw new Exception("Project not found");
        var skill = _context.Skills.Find(sId) ?? throw new Exception("Skill not found");

        project.Skills.Add(skill);
        _context.SaveChanges();
        
        return project;
    }

    public IEnumerable<Project> GetAll()
    {
        return _context.Projects;
    }

    public Project? GetById(int id)
    {
        var project = _context.Projects
                        .Include(p => p.Skills)
                        .FirstOrDefault(p => p.Id == id) 
                        ?? throw new Exception("Project not found");
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

    public Project? DeleteRelationship(int pId, int sId)
    {
        var project = _context.Projects
                        .Include(p => p.Skills)
                        .FirstOrDefault(p => p.Id == pId) 
                        ?? throw new Exception("Project not found");
        var skill = _context.Skills.Find(sId) ?? throw new Exception("Skill not found");


        project.Skills.Remove(skill);
        _context.SaveChanges();

        return project;
    }

}