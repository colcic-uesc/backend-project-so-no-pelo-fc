using System;
using BackEndAPI.Core;

namespace BackEndAPI.Service.DataBase.Interfaces;

public interface IStudentCRUD : IBaseCRUD<Student> 
{
    Student? GetByRegistration(string registration);
}