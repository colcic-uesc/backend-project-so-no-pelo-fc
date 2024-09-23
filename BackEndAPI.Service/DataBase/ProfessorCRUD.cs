using System;
using BackEndAPI.Core;
using BackEndAPI.Service.DataBase.Interfaces;

namespace BackEndAPI.Service.DataBase;

public class ProfessorCRUD : IProfessorCRUD
{
    private static readonly List<Professor> _professors = new List<Professor>
        {
            new Professor { Id = 1, Name = "Carlos Silva", Email = "carlos.silva@universidade.edu", Department = "Matemática", Bio = "Professor de matemática aplicada com foco em estatísticas." },
            new Professor { Id = 2, Name = "Maria Fernandes", Email = "maria.fernandes@universidade.edu", Department = "Física", Bio = "Especialista em física quântica e partículas." },
            new Professor { Id = 3, Name = "João Barreto", Email = "joao.barreto@universidade.edu", Department = "Ciências da Computação", Bio = "Interesses incluem inteligência artificial e aprendizado de máquina." }
        };

    public void Create(Professor entity)
    {
        entity.Id = _professors.Count > 0 ? _professors.Max(p => p.Id) + 1 : 1; // Auto-increment Id
        _professors.Add(entity);
    }

    public void Delete(int id)
    {
        var professor = _professors.FirstOrDefault(p => p.Id == id);
        if (professor is null) return;

        _professors.Remove(professor);
    }

    public IEnumerable<Professor> GetAll()
    {
        return _professors;
    }

    public Professor? GetById(int id)
    {
        return _professors.FirstOrDefault(p => p.Id == id);
    }

    public void Update(Professor entity)
    {
        var professor = _professors.FirstOrDefault(p => p.Id == entity.Id);
        if (professor == null) return;

        professor.Name = entity.Name;
        professor.Email = entity.Email;
        professor.Department = entity.Department;
        professor.Bio = entity.Bio;
    }
}
