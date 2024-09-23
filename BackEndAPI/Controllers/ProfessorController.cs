using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using BackEndAPI.Service.DataBase.Interfaces;
using BackEndAPI.Core;

namespace BackEndAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfessorController : ControllerBase
{
    private readonly IProfessorCRUD _professorsCRUD;

    public ProfessorController(IProfessorCRUD professorsCRUD)
    {
        _professorsCRUD = professorsCRUD;
    }

    [HttpGet(Name = "GetProfessors")]
    public IEnumerable<Professor> Get()
    {
        return _professorsCRUD.GetAll();
    }

    [HttpGet("{id}", Name = "GetProfessor")]
    public ActionResult<Professor> Get(int id)
    {
        try
        {
            var professor = _professorsCRUD.GetById(id);
            if(professor is null) 
            {
                return NotFound($"Professor with Id {id} not found.");
            }

            return Ok(professor);
        }
        catch (Exception e) 
        {
            return StatusCode(500, $"Internal server error: {e.Message}");
        }
    }

    [HttpPost(Name = "CreateProfessor")]
    public void Create(Professor professor)
    {
        _professorsCRUD.Create(professor);
    }

    [HttpPut(Name = "UpdateProfessor")]
    public void Update(Professor professor)
    {
        _professorsCRUD.Update(professor);
    }

    [HttpDelete("{id}", Name = "DeleteProfessor")]
    public void Delete(int id)
    {
        _professorsCRUD.Delete(id);
    }
}