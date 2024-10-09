using Microsoft.AspNetCore.Mvc;
using BackEndAPI.Service.DataBase.Interfaces;
using BackEndAPI.Core;
using BackEndAPI.Core.Dtos;

namespace BackEndAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectCRUD _projectsCRUD;

    public ProjectsController(IProjectCRUD projectsCRUD)
    {
        _projectsCRUD = projectsCRUD;
    }

    [HttpGet(Name = "GetProjects")]
    public IEnumerable<Project> Get()
    {
        return _projectsCRUD.GetAll();
    }

    [HttpGet("{id}/skills", Name = "GetProject")]
    public ActionResult<Project> Get(int id)
    {
        try
        {
            var project = _projectsCRUD.GetById(id);
            if(project is null) 
            {
                return NotFound($"Project with Id {id} not found.");
            }

            return Ok(project);
        }
        catch (Exception e) 
        {
            return StatusCode(500, $"Internal server error: {e.Message}");
        }
    }

    [HttpPost(Name = "CreateProject")]
    public void Create(ProjectCreateDto dto)
    {
        _projectsCRUD.Create(
            new Project
            {
                Id = dto.Id,
                Description = dto.Description,
                StartDate = dto.StartDate,
                Title = dto.Title,
                Type = dto.Type,
                EndDate = dto.EndDate,
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
                Description = dto.Description,
                StartDate = dto.StartDate,
                Title = dto.Title,
                Type = dto.Type,
                EndDate = dto.EndDate,
            } 
        );
    }

    [HttpPut("{projectId}/skills/{skillId}", Name = "UpdateProjectSkillRelationship")]
    public IActionResult ProjectSkillUpdate(int projectId, int skillId)
    {
        try
        {
            var project = _projectsCRUD.CreateRelationship(projectId, skillId);
            if(project is null) 
            {
                return NotFound($"Erro ao criar relacionamento. Projeto ou Skill nao encontrada.");
            }

            return Ok(project);
        }
        catch (System.Exception e)
        {
            return StatusCode(500, $"Internal server error: {e.Message}");
        }
    }

    [HttpDelete("{id}", Name = "DeleteProject")]
    public void Delete(int id)
    {
        _projectsCRUD.Delete(id);
    }
}