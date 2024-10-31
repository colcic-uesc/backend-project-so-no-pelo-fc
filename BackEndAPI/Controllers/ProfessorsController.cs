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
    private readonly IUserCRUD _usersCRUD;

    public ProfessorsController(IProfessorCRUD professorsCRUD, IUserCRUD usersCRUD)
    {
        _professorsCRUD = professorsCRUD;
        _usersCRUD = usersCRUD;
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
            if(professor is null) 
            {
                return NotFound($"Professor with Id {id} not found.");
            }

            return Ok(ProfessorObjectToGetDto(professor));
        }
        catch (Exception e) 
        {
            return StatusCode(500, $"Internal server error: {e.Message}");
        }
    }

    [HttpPost(Name = "CreateProfessor")]
    public void Create(ProfessorCreateDto dto)
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
    }

    [HttpPut("{id}", Name = "UpdateProfessor")]
    public void Update(int id, [FromBody] ProfessorUpdateDto dto)
    {
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
    }

    [HttpDelete("{id}", Name = "DeleteProfessor")]
    public void Delete(int id)
    {
        _professorsCRUD.Delete(id);
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