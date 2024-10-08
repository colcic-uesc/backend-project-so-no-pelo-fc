using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using BackEndAPI.Service.DataBase.Interfaces;
using BackEndAPI.Core;

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
    public IEnumerable<Student> Get()
    {
        return _studentCRUD.GetAll();
    }

    [HttpGet("register/{registration}", Name = "GetStudentByRegistration")]
    public ActionResult<Student> Get(string registration)
    {
        var student = _studentCRUD.GetByRegistration(registration);
        if(student is null) 
        {
            return NotFound($"Student with registration {registration} not found.");
        }

        return Ok(student);
    }

    [HttpGet("{id}", Name = "GetStudent")]
    public ActionResult<Student> Get(int id)
    {
        try
        {
            var student = _studentCRUD.GetById(id);
            if(student is null) 
            {
                return NotFound($"Student with Id {id} not found.");
            }

            return Ok(student);
        }
        catch (Exception e) 
        {
            return StatusCode(500, $"Internal server error: {e.Message}");
        }
    }

    [HttpPost(Name = "CreateStudent")]
    public void Create(Student student)
    {
        _studentCRUD.Create(student);
    }

    [HttpPut(Name = "UpdateStudent")]
    public void Update(Student student)
    {
        _studentCRUD.Update(student);
    }

    [HttpDelete("{id}", Name = "DeleteStudent")]
    public void Delete(int id)
    {
        _studentCRUD.Delete(id);
    }
}