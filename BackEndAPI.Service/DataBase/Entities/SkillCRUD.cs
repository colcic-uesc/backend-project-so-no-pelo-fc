using System;
using BackEndAPI.Core;
using BackEndAPI.Service.DataBase.Interfaces;

namespace BackEndAPI.Service.DataBase.Entities;

public class SkillCRUD : ISkillCRUD
{
    private static readonly List<Skill> _skills = new List<Skill>
    {
        new Skill { Id = 1, Title = "Programming", Description = "Ability to write computer programs in various languages." },
        new Skill { Id = 2, Title = "Web Design", Description = "Skills in designing functional and attractive web pages." },
        new Skill { Id = 3, Title = "Project Management", Description = "Ability to manage projects efficiently and lead teams." },
        new Skill { Id = 4, Title = "Data Analysis", Description = "Expertise in analyzing complex datasets to extract actionable insights." },
        new Skill { Id = 5, Title = "Mobile Development", Description = "Ability to develop applications for mobile devices on platforms like Android and iOS." },
        new Skill { Id = 6, Title = "UI/UX Design", Description = "Skills in designing user interfaces and experiences that are both intuitive and engaging." }
    };

    public void Create(Skill entity)
    {
        entity.Id = _skills.Count > 0 ? _skills.Max(p => p.Id) + 1 : 1; // Auto-increment Id
        _skills.Add(entity);
    }

    public void Delete(int id)
    {
        var skill = _skills.FirstOrDefault(x => x.Id == id);
        if (skill is null) return;

        _skills.Remove(skill);
    }

    public IEnumerable<Skill> GetAll()
    {
        return _skills;
    }

    public Skill? GetById(int id)
    {
        return _skills.FirstOrDefault(x => x.Id == id);
    }

    public void Update(Skill entity)
    {
        var skill = _skills.FirstOrDefault(x => x.Id == entity.Id);
        if (skill == null) return;

        skill.Title = entity.Title;
        skill.Description = entity.Description;
    }
}
