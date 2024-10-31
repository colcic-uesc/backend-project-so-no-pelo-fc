using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using BackEndAPI.Service.DataBase.Interfaces;
using BackEndAPI.Core;
using BackEndAPI.Core.Dtos.User;

namespace BackEndAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentCRUD _studentCRUD;

    public StudentsController(IStudentCRUD studentCRUD)
    {
        _studentCRUD = studentCRUD;
    }

    [HttpGet(Name = "GetStudents")]
    public IEnumerable<StudentGetDto> Get()
    {
        var students = _studentCRUD.GetAll()
                                    .Select(StudentObjectToGetDto);
        return students;
    }

    [HttpGet("register/{registration}", Name = "GetStudentByRegistration")]
    public ActionResult<StudentGetDto> Get(string registration)
    {
        var student = _studentCRUD.GetByRegistration(registration);
        if(student is null) 
        {
            return NotFound($"Student with registration {registration} not found.");
        }

        return Ok(StudentObjectToGetDto(student));
    }

    [HttpGet("{id}", Name = "GetStudent")]
    public ActionResult<StudentGetDto> Get(int id)
    {
        try
        {
            var student = _studentCRUD.GetById(id);
            if(student is null) 
            {
                return NotFound($"Student with Id {id} not found.");
            }

            return Ok(StudentObjectToGetDto(student));
        }
        catch (Exception e) 
        {
            return StatusCode(500, $"Internal server error: {e.Message}");
        }
    }

    [HttpPost(Name = "CreateStudent")]
    public void Create(StudentCreateDto dto)
    {
        _studentCRUD.Create(
            new Student {
                Bio  =dto.Bio,
                Course =dto.Course,
                Name = dto.Name,
                Email = dto.Email,
                Registration = dto.Registration,
                User = new User {
                    Username = dto.User.Username,
                    Password = dto.User.Password,
                    Rules = dto.User.Rules
                }
            }
        );
    }

    [HttpPut("{id}", Name = "UpdateStudent")]
    public void Update(int id, [FromBody] StudentUpdateDto dto)
    {
        _studentCRUD.Update(
            new Student {
                Id = id,
                Bio = dto.Bio,
                Course = dto.Course,
                Name = dto.Name,
                Email = dto.Email,
                Registration = dto.Registration,
                User = new User {
                    Username = dto.User.Username,
                    Rules = dto.User.Rules
                }
            }
        );
    }

    [HttpDelete("{id}", Name = "DeleteStudent")]
    public void Delete(int id)
    {
        _studentCRUD.Delete(id);
    }

    private static StudentGetDto StudentObjectToGetDto(Student student)
    {
        return new StudentGetDto {
            Id = student.Id,
            Bio  =student.Bio,
            Course =student.Course,
            Name = student.Name,
            Email = student.Email,
            Registration = student.Registration,
            User = new UserGetDto {
                Username = student.User.Username,
                Rules = student.User.Rules
            }
        };
    }
}