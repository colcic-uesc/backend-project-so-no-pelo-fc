using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using BackEndAPI.Service.DataBase.Interfaces;
using BackEndAPI.Core;
using BackEndAPI.Core.Dtos;

namespace BackEndAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SkillsController : ControllerBase
{
    private readonly IProjectSkillCRUD _relations;
    private readonly ISkillCRUD _skillCRUD;

    public SkillsController( IProjectSkillCRUD relations,ISkillCRUD skillCRUD)
    {
        _skillCRUD = skillCRUD;
        _relations = relations;
    }

    [HttpGet(Name = "GetSkills")]
    public IEnumerable<Skill> Get([FromQuery] bool? includeProjects = false)
    {
        var skills = _relations.GetSkills();

        if (includeProjects != true)
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
    public void Create(SkillCreateDto dto)
    {
        _skillCRUD.Create(
            new Skill
            {
                Id = dto.Id,
                Description = dto.Description,
                Title = dto.Title
            }
        );
    }

    [HttpPut(Name = "UpdateSkill")]
    public void Update(SkillUpdateDto dto)
    {
        _skillCRUD.Update(
            new Skill
            {
                Id = dto.Id,
                Description = dto.Description,
                Title = dto.Title
            }
        );
    }

    [HttpDelete("{id}", Name = "DeleteSkill")]
    public void Delete(int id)
    {
        _skillCRUD.Delete(id);
    }
}