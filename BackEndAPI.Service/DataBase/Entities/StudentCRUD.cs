using System;
using BackEndAPI.Core;
using BackEndAPI.Service.DataBase.Interfaces;

namespace BackEndAPI.Service.DataBase.Entities;
public class StudentCRUD : IStudentCRUD
{

    private static readonly List<Students> _studentList = new List<Students>
    {
        new Students { Id = 1, Registration = "REG001", Name = "Ana Silva", Email = "ana.silva@university.com", Course = "Computer Science", Bio = "Ana is a computer science student interested in AI and machine learning.", Skills = [] },
        new Students { Id = 2, Registration = "REG002", Name = "Marcos Andrade", Email = "marcos.andrade@university.com", Course = "Business Administration", Bio = "Marcos is specializing in finance and business strategy.", Skills = [] },
        new Students { Id = 3, Registration = "REG003", Name = "Leticia Costa", Email = "leticia.costa@university.com", Course = "Mechanical Engineering", Bio = "Leticia is involved in several projects related to renewable energy.", Skills = [] }
    };

    public void Create(Students entity)
    {
        entity.Id = _studentList.Count > 0 ? _studentList.Max(p => p.Id) + 1 : 1; // Auto-increment Id
        _studentList.Add(entity);
    }

    public void Delete(int id)
    {
        var student = _studentList.FirstOrDefault(x => x.Id == id);
        if (student is null) return;

        _studentList.Remove(student);
    }

    public IEnumerable<Students> GetAll()
    {
        return _studentList;
    }

    public Students? GetById(int id)
    {
        return _studentList.FirstOrDefault(x => x.Id == id);
    }

    public Students? GetByRegistration(string registration)
    {
        return _studentList.FirstOrDefault(x => x.Registration == registration);
    }

    public void Update(Students entity)
    {
        var student = _studentList.FirstOrDefault(x => x.Id == entity.Id);
        if (student == null) return;

        student.Name = entity.Name;
        student.Registration = entity.Registration;
        student.Email = entity.Email;
        student.Course = entity.Course;
        student.Bio = entity.Bio;
        student.Skills = entity.Skills;
    }
}

