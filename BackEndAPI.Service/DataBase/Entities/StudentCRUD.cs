using System;
using BackEndAPI.Core;
using BackEndAPI.Service.DataBase.Interfaces;

namespace BackEndAPI.Service.DataBase.Entities;
public class StudentCRUD : IStudentCRUD
{
    private readonly ApiDBContext _context;
    public StudentCRUD(ApiDBContext context)
    {
        _context = context;
    }

    public void Create(Student entity)
    {
        _context.Students.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var student = _context.Students.Find(id) ?? throw new Exception("Student not found");
        _context.Students.Remove(student);
        _context.SaveChanges();
    }

    public IEnumerable<Student> GetAll()
    {
        return _context.Students;
    }

    public Student? GetById(int id)
    {
        var student = _context.Students.Find(id) ?? throw new Exception("Student not found");
        return student;
    }

    public Student? GetByRegistration(string registration)
    {
        var student = _context.Students.FirstOrDefault(s => s.Registration == registration) ?? throw new Exception("Student not found");
        return student;
    }

    public void Update(Student entity)
    {
        var student = _context.Students.Find(entity.Id) ?? throw new Exception("Student not found");
        student.Name = entity.Name;
        student.Email = entity.Email;
        student.Course = entity.Course;
        student.Registration = entity.Registration;
        student.Bio = entity.Bio;
        _context.SaveChanges();
    }  
}

