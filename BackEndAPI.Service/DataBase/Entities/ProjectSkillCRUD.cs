using System;
using BackEndAPI.Core;
using BackEndAPI.Service.DataBase.Interfaces;


namespace BackEndAPI.Service.DataBase.Entities;

public class ProjectSkillCRUD : IProjectSkillCRUD
{
    private static readonly List<ProjectSkill> _relations = new()
    {
        new ProjectSkill
        {
            ProjectId=1,
            SkillId=1
        },
        new ProjectSkill
        {
            ProjectId=1,
            SkillId=2
        }
    };

    private readonly IProjectCRUD _projects;

    private readonly ISkillCRUD _skills;

    public IEnumerable<Project> GetProjects()
    {
        return _projects.GetAll();
    }

    public IEnumerable<Skill> GetSkills()
    {
        return _skills.GetAll();
    }

    public ProjectSkillCRUD(IProjectCRUD projectCRUD, ISkillCRUD skillCRUD)
    {
        _projects = projectCRUD;
        _skills = skillCRUD;
    }

    public void Create(ProjectSkill entity)
    {
        var project = _projects.GetById(entity.ProjectId);
        var skill = _skills.GetById(entity.SkillId);
        if (project is null || skill is null)
        {
            return;
        }

        var relation = _relations.FirstOrDefault(entity);

        if (relation is not null)
        {
            return;
        }

        _relations.Add(entity);

    }

    public void Delete(int id)
    {
        var relation = _relations.FirstOrDefault(r => r.Id == id);
        if (relation is not null)
        {
            _relations.Remove(relation);
        }
    }

    public IEnumerable<ProjectSkill> GetAll()
    {
        return _relations;
    }

    public ProjectSkill? GetById(int id)
    {
        return _relations.FirstOrDefault(r => r.Id == id);
    }

    public void Update(ProjectSkill entity)
    {
        var relation = _relations.FirstOrDefault(r => r.Id == entity.Id);
        if (relation is null)
        {
            return;
        }
        relation.ProjectId = entity.ProjectId;
        relation.SkillId = entity.SkillId;
    }

    public Skill? GetSkillById(int id)
    {
        return _skills.GetById(id);
    }

    public Project? GetProjectById(int id)
    {
        return _projects.GetById(id);
    }

    public List<Skill> GetRelatedSkillsOf(Project project)
    {
        var relatedSkills = new List<Skill>();
        foreach (var relation in _relations)
        {
            if (relation.ProjectId == project.Id)
            {
                var skill = _skills.GetById(relation.SkillId);
                if (skill != null)
                {
                    relatedSkills.Add(skill);
                }
            }
        }
        return relatedSkills;
    }

    public List<Project> GetRelatedProjectsOf(Skill skill)
    {
        var relatedProjects = new List<Project>();
        foreach (var relation in _relations)
        {
            if (relation.SkillId == skill.Id)
            {
                var project = _projects.GetById(relation.ProjectId);
                if (project != null)
                {
                    relatedProjects.Add(project);
                }
            }
        }
        return relatedProjects;
    }
}