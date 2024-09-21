using System;

namespace BackEndAPI.Service.DataBase.Interfaces;

public interface IBaseCRUD<T>
{
    public void Create(T entity);
    public IEnumerable<T> GetAll();
    public T? GetById(int id);
    public void Update(T entity);
    public void Delete(int id);
}