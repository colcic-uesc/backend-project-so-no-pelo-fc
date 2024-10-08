using System;
using BackEndAPI.Core;
using BackEndAPI.Service.DataBase.Interfaces;

namespace BackEndAPI.Service.DataBase.Entities;

public class ProfessorCRUD : IProfessorCRUD
{   
    private readonly ApiDBContext _context;
    public ProfessorCRUD(ApiDBContext context)
    {
        _context = context;
    }

    public void Create(Professor entity)
    {
        _context.Professors.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var professor = _context.Professors.Find(id) ?? throw new Exception("Professor not found");
        _context.Professors.Remove(professor);
        _context.SaveChanges();
    }

    public IEnumerable<Professor> GetAll()
    {
        return _context.Professors;
    }

    public Professor? GetById(int id)
    {   
        var professor = _context.Professors.Find(id) ?? throw new Exception("Professor not found");
        return professor;
    }

    public void Update(Professor entity)
    {
        var professor = _context.Professors.Find(entity.Id) ?? throw new Exception("Professor not found");
        professor.Name = entity.Name;
        professor.Email = entity.Email;
        professor.Department = entity.Department;
        professor.Bio = entity.Bio;
        _context.SaveChanges();
    }
}
