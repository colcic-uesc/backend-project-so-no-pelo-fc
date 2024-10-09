using System;
using BackEndAPI.Core;

namespace BackEndAPI.Service.DataBase.Interfaces;

public interface IProjectCRUD : IBaseCRUD<Project> 
{
    public Project? CreateRelationship(int pId, int sId);
}