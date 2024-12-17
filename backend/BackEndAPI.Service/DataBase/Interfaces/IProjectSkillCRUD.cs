using System;
using System.Net.Http.Headers;
using BackEndAPI.Core;

namespace BackEndAPI.Service.DataBase.Interfaces;

public interface IProjectSkillCRUD : IBaseCRUD<ProjectSkill>
{
    public IEnumerable<Project> GetProjects();

    public IEnumerable<Skill> GetSkills();

    public List<Skill> GetRelatedSkillsOf(Project project);

    public List<Project> GetRelatedProjectsOf(Skill skill);

    public Skill? GetSkillById(int id);

    public Project? GetProjectById(int id);
}