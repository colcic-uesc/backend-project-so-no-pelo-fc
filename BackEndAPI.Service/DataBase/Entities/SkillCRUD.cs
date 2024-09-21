using System;
using BackEndAPI.Core;
using BackEndAPI.Service.DataBase.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackEndAPI.Service.DataBase.Entities;

public class SkillCRUD : ISkillCRUD
{
    private readonly ApiDBContext _context;
    public SkillCRUD(ApiDBContext context)
    {
        _context = context;
    }

    public void Create(Skill entity)
    {
        _context.Skills.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var skill = _context.Skills.Find(id) ?? throw new Exception("Skill not found");
        _context.Skills.Remove(skill);
        _context.SaveChanges();
    }

    public IEnumerable<Skill> GetAll()
    {
        return _context.Skills;
    }

    public Skill? GetById(int id)
    {
        var skill = _context.Skills
                    .Include(s => s.Projects)
                    .FirstOrDefault(s => s.Id == id) ?? throw new Exception("Skill not found");
        return skill;
    }

    public void Update(Skill entity)
    {
        var skill = _context.Skills.Find(entity.Id) ?? throw new Exception("Skill not found");
        skill.Title = entity.Title;
        skill.Description = entity.Description;
        _context.SaveChanges();
    }
}
