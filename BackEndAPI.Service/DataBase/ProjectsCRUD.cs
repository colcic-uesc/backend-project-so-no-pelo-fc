using System;
using BackEndAPI.Core;
using BackEndAPI.Service.DataBase.Interfaces;


namespace BackEndAPI.Service.DataBase;

public class ProjectCRUD : IProjectCRUD
{

    private static readonly List<Project> _projects = new List<Project>
    {
        new Project { Id = 1, Title = "Desenvolvimento de Website", Description = "Projeto de criação de um site institucional.", Type = "Web Development", StartDate = new DateTime(2023, 1, 1), EndDate = new DateTime(2023, 6, 1), Skills = []},
        new Project { Id = 2, Title = "Desenvolvimento de App", Description = "Projeto para desenvolvimento de um aplicativo móvel.", Type = "Mobile Development", StartDate = new DateTime(2023, 2, 15), EndDate = new DateTime(2023, 8, 15), Skills = []},
        new Project { Id = 3, Title = "Sistema de Gestão", Description = "Desenvolvimento de um sistema de gestão empresarial.", Type = "Software Development", StartDate = new DateTime(2023, 5, 20), EndDate = new DateTime(2023, 12, 20), Skills = []}
    };

    public void Create(Project entity)
    {
        entity.Id = _projects.Count > 0 ? _projects.Max(p => p.Id) + 1 : 1; // Auto-increment Id
        _projects.Add(entity);
    }

    public void Delete(int id)
    {
        Console.WriteLine($"deleting with id {id}");
        var project = _projects.FirstOrDefault(p => p.Id == id);
        if (project is null) return;

        _projects.Remove(project); 
          Console.WriteLine(string.Join(", ", _projects));
    }

    public IEnumerable<Project> GetAll()
    {
        return _projects;
    }

    public Project? GetById(int id)
    {
        return _projects.FirstOrDefault(p => p.Id == id);
    }

    public void Update(Project updatedProject)
    {
        var project = _projects.FirstOrDefault(p => p.Id == updatedProject.Id);
        if (project == null) return;

        project.Title = updatedProject.Title;
        project.Description = updatedProject.Description;
        project.Type = updatedProject.Type;
        project.StartDate = updatedProject.StartDate;
        project.EndDate = updatedProject.EndDate;
        project.Skills = updatedProject.Skills;
    }
}