using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using BackEndAPI.Service.DataBase.Interfaces;
using BackEndAPI.Core;

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

    [HttpGet("{id}", Name = "GetProject")]
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

    [HttpPost(Name = "CreateProjet")]
    public void Create(Project project)
    {
        _projectsCRUD.Create(project);
    }

    [HttpPut(Name = "UpdateProject")]
    public void Update(Project project)
    {
        _projectsCRUD.Update(project);
    }

    [HttpDelete("{id}", Name = "DeleteProject")]
    public void Delete(int id)
    {
        _projectsCRUD.Delete(id);
    }
}