using System;
using BackEndAPI.Core;
using BackEndAPI.Service.DataBase.Interfaces;

namespace BackEndAPI.Service.DataBase.Entities;

public class UserCRUD : IUserCRUD
{
    private readonly ApiDBContext _context;

    public UserCRUD(ApiDBContext context)
    {
        _context = context;
    }
    public void Create(User entity)
    {
        _context.Users.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var user = _context.Users.Find(id) ?? throw new Exception("User not found");
        _context.Users.Remove(user);
        _context.SaveChanges();
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users;
    }

    public User? GetById(int id)
    {
        var user = _context.Users.Find(id);
        return user;
    }

    public User? GetByUsername(string userName)
    {
        var user = _context.Users.FirstOrDefault(user => user.Username == userName);
        return user;
    }

    public void Update(User entity)
    {
        var user = _context.Users.Find(entity.Id) ?? throw new Exception("User not found");
        user.Username = entity.Username;
        user.Password = entity.Password;
        user.Rules = entity.Rules;
        _context.SaveChanges();
    }
}