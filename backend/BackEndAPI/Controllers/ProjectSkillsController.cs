using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using BackEndAPI.Service.DataBase.Interfaces;
using BackEndAPI.Core;

namespace BackEndAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectSkillsController : ControllerBase
{
    private readonly IProjectSkillCRUD _relations;

    public ProjectSkillsController(IProjectSkillCRUD projectSkillCRUD)
    {
        _relations = projectSkillCRUD;
    }

    [HttpGet(Name = "GetProjectSkillRelation")]
    public IEnumerable<ProjectSkill> Get()
    {
        return _relations.GetAll();
    }

    [HttpGet("{id}", Name = "GetProjectSkillRelations")]
    public ActionResult<Professor> Get(int id)
    {
        try
        {
            var relation = _relations.GetById(id);
            if(relation is null) 
            {
                return NotFound($"Project Skill Relation with Id {id} not found.");
            }

            return Ok(relation);
        }
        catch (Exception e) 
        {
            return StatusCode(500, $"Internal server error: {e.Message}");
        }
    }

    [HttpPost(Name = "CreateProjectSkillRelation")]
    public void Create(ProjectSkill relation)
    {
        _relations.Create(relation);
    }

    [HttpPut(Name = "UpdateProjectSkillRelation")]
    public void Update(ProjectSkill relation)
    {
        _relations.Update(relation);
    }

    [HttpDelete("{id}", Name = "DeleteProjectSkillRelation")]
    public void Delete(int id)
    {
        _relations.Delete(id);
    }
}