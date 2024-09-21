using Microsoft.AspNetCore.Mvc;
using BackEndAPI.Service.DataBase.Interfaces;
using BackEndAPI.Core;
using BackEndAPI.Core.Dtos;

namespace BackEndAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SkillsController : ControllerBase
{
    private readonly ISkillCRUD _skillsCRUD;

    public SkillsController(ISkillCRUD skillsCRUD)
    {
        _skillsCRUD = skillsCRUD;
    }

    [HttpGet(Name = "GetSkills")]
    public IEnumerable<Skill> Get()
    {
        return _skillsCRUD.GetAll();
    }

    [HttpGet("{id}/projects", Name = "GetSkill")]
    public ActionResult<Skill> Get(int id)
    {
        try
        {
            var skill = _skillsCRUD.GetById(id);
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
    public void Create(SkillCreateDto dto)
    {
        _skillsCRUD.Create(
            new Skill
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
            } 
        );
    }

    [HttpPut(Name = "UpdateSkill")]
    public void Update(SkillUpdateDto dto)
    {
        _skillsCRUD.Update(
            new Skill
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
            } 
        );
    }

    [HttpDelete("{id}", Name = "DeleteSkill")]
    public void Delete(int id)
    {
        _skillsCRUD.Delete(id);
    }
}