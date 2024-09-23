using System;
using BackEndAPI.Core;

namespace BackEndAPI.Service.DataBase.Interfaces;

public interface IStudentCRUD : IBaseCRUD<Students> 
{
    Students? GetByRegistration(string registration);
}