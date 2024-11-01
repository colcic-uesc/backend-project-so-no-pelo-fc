using System;
using BackEndAPI.Core;
using BackEndAPI.Service.DataBase.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        var professor = _context.Professors.FirstOrDefault(p => p.Id == id);
        _context.Professors.Remove(professor!);
        _context.SaveChanges();
    }

    public IEnumerable<Professor> GetAll()
    {
        return _context.Professors.Include("User");
    }

    public Professor? GetById(int id)
    {   
        var professor = _context.Professors.Include("User").FirstOrDefault(p => p.Id == id);
        
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
