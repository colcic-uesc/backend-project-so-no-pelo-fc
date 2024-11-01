using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using BackEndAPI.Service.DataBase.Interfaces;
using BackEndAPI.Core;
using BackEndAPI.Core.Dtos.Professor;
using BackEndAPI.Core.Dtos.User;

namespace BackEndAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfessorsController : ControllerBase
{
    private readonly IProfessorCRUD _professorsCRUD;

    public ProfessorsController(IProfessorCRUD professorsCRUD)
    {
        _professorsCRUD = professorsCRUD;
    }

    [HttpGet(Name = "GetProfessors")]
    public IEnumerable<ProfessorGetDto> Get()
    {
        var professors = _professorsCRUD.GetAll()
                                        .Select(ProfessorObjectToGetDto); 
        return professors;
    }

    [HttpGet("{id}", Name = "GetProfessor")]
    public ActionResult<ProfessorGetDto> Get(int id)
    {
        try
        {
            var professor = _professorsCRUD.GetById(id);
            if(professor is null) return NotFound($"Professor with Id {id} not found.");

            return Ok(ProfessorObjectToGetDto(professor));
        }
        catch (Exception e) 
        {
            Console.WriteLine("catch");

            return StatusCode(500, $"Internal server error: {e.Message}");
        }
    }

    [HttpPost(Name = "CreateProfessor")]
    public IActionResult Create(ProfessorCreateDto dto)
    {   
        try
        {
            _professorsCRUD.Create(
                new Professor {
                    Name = dto.Name,
                    Email = dto.Email,
                    Department = dto.Department,
                    Bio = dto.Bio,
                    User = new User {
                        Username = dto.User.Username,
                        Password = dto.User.Password,
                        Rules = dto.User.Rules
                    }
                }
            );

            return Created();
        }
        catch (System.Exception e)
        {
            return StatusCode(500, $"Internal server error: {e.Message}");
        }
        
    }

    [HttpPut("{id}", Name = "UpdateProfessor")]
    public IActionResult Update(int id, [FromBody] ProfessorUpdateDto dto)
    {
        try
        {
            if(_professorsCRUD.GetById(id) is null) return NotFound();

            _professorsCRUD.Update(
                new Professor {
                    Id = id,
                    Name = dto.Name,
                    Email = dto.Email,
                    Department = dto.Department,
                    Bio = dto.Bio,
                    User = new User {
                        Username = dto.User.Username,
                        Rules = dto.User.Rules
                    }
                }
            );

            return NoContent();
        }
        catch (System.Exception e)
        {
             return StatusCode(500, $"Internal server error: {e.Message}");
        }
    }

    [HttpDelete("{id}", Name = "DeleteProfessor")]
    public IActionResult Delete(int id)
    {
        try
        {
            if(_professorsCRUD.GetById(id) is null) return NotFound();
            _professorsCRUD.Delete(id);

            return NoContent();
        }
        catch (System.Exception e)
        {
            return StatusCode(500, $"Internal server error: {e.Message}");
        }
        
    }

    private static ProfessorGetDto ProfessorObjectToGetDto(Professor professor) {
        return new ProfessorGetDto {
            Id = professor.Id,
            Name = professor.Name,
            Bio =professor.Bio,
            Email = professor.Email,
            Department = professor.Department,
            User = professor.User != null ? new UserGetDto {
                Username = professor.User.Username,
                Rules = professor.User.Rules
            } : null
        };
    }
}