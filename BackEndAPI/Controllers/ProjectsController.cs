using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using BackEndAPI.Service.DataBase.Interfaces;
using BackEndAPI.Core;
using BackEndAPI.Service.DataBase.Entities;
using BackEndAPI.Core.Dtos;

namespace BackEndAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectSkillCRUD _relations;
    private readonly IProjectCRUD _projectsCRUD;

    public ProjectsController(IProjectSkillCRUD projectsSkillCRUD, IProjectCRUD projectCRUD)
    {
        _relations = projectsSkillCRUD;
        _projectsCRUD = projectCRUD;
    }

    [HttpGet(Name = "GetProjects")]
    public IEnumerable<Project> Get([FromQuery] bool? includeSkills = false)
    {
        var projects = _relations.GetProjects();

        if (includeSkills != true)
        {
            foreach (var project in projects)
            {
                project.Skills = null;  
            }

            return projects;
        }

        foreach (var project in projects)
        {
            project.Skills = _relations.GetRelatedSkillsOf(project);
        }

        return projects;
    }

    [HttpGet("{id}", Name = "GetProject")]
    public ActionResult<Project> Get(int id)
    {
        try
        {
            var project = _relations.GetProjectById(id);
            
            if (project is null)
            {
                return NotFound($"Project with Id {id} not found.");
            }

            project.Skills = _relations.GetRelatedSkillsOf(project);
            
            return Ok(project);
        }
        catch (Exception e)
        {
            return StatusCode(500, $"Internal server error: {e.Message}");
        }
    }

    [HttpPost(Name = "CreateProjet")]
    public void Create(ProjectCreateDto dto)
    {
        _projectsCRUD.Create(
            new Project
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                Type = dto.Type,
                StartDate =dto.StartDate,
                EndDate = dto.EndDate
            }
        );
    }

    [HttpPut(Name = "UpdateProject")]
    public void Update(ProjectUpdateDto dto)
    {
        _projectsCRUD.Update(
            new Project
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                Type = dto.Type,
                StartDate =dto.StartDate,
                EndDate = dto.EndDate
            }
        );
    }

    [HttpDelete("{id}", Name = "DeleteProject")]
    public void Delete(int id)
    {
        _projectsCRUD.Delete(id);
    }
}