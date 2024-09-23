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
    private readonly ISkillCRUD _skillCRUD;

    public SkillController(ISkillCRUD skillCRUD)
    {
        _skillCRUD = skillCRUD;
    }

    [HttpGet(Name = "GetSkills")]
    public IEnumerable<Skill> Get()
    {
        return _skillCRUD.GetAll();
    }

    [HttpGet("{id}", Name = "GetSkill")]
    public ActionResult<Skill> Get(int id)
    {
        try
        {
            var skill = _skillCRUD.GetById(id);
            if(skill is null) 
            {
                return NotFound($"Skill with Id {id} not found.");
            }

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