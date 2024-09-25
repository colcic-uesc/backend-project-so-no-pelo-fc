using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using BackEndAPI.Service.DataBase.Interfaces;
using BackEndAPI.Core;

namespace BackEndAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SkillController : ControllerBase
{
    private readonly IProjectSkillCRUD _relations;
    private readonly ISkillCRUD _skillCRUD;

    public SkillController( IProjectSkillCRUD relations,ISkillCRUD skillCRUD)
    {
        _skillCRUD = skillCRUD;
        _relations = relations;
    }

    [HttpGet(Name = "GetSkills")]
    public IEnumerable<Skill> Get([FromQuery] bool? includeSkills = false)
    {
        var skills = _relations.GetSkills();

        if (includeSkills != true)
        {
            foreach (var skill in skills)
            {
                skill.Projects = null;  
            }

            return skills;
        }

        foreach (var skill in skills)
        {
            skill.Projects = _relations.GetRelatedProjectsOf(skill);
        }

        return skills;
    }

    [HttpGet("{id}", Name = "GetSkill")]
    public ActionResult<Skill> Get(int id)
    {
        try
        {
           var skill = _relations.GetSkillById(id);
            
            if (skill is null)
            {
                return NotFound($"skill with Id {id} not found.");
            }

            skill.Projects = _relations.GetRelatedProjectsOf(skill);
            
            return Ok(skill);
        }
        catch (Exception e) 
        {
            return StatusCode(500, $"Internal server error: {e.Message}");
        }
    }

    [HttpPost(Name = "CreateSkill")]
    public void Create(Skill skill)
    {
        _skillCRUD.Create(skill);
    }

    [HttpPut(Name = "UpdateSkill")]
    public void Update(Skill skill)
    {
        _skillCRUD.Update(skill);
    }

    [HttpDelete("{id}", Name = "DeleteSkill")]
    public void Delete(int id)
    {
        _skillCRUD.Delete(id);
    }
}