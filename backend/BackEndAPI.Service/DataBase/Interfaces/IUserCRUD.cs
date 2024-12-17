using System;
using BackEndAPI.Core;
using BackEndAPI.Core.Dtos;

namespace BackEndAPI.Service.DataBase.Interfaces;

public interface IUserCRUD : IBaseCRUD<User>
{
    User? GetByUsername(string userName); 
}