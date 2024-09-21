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
            Id=1,
            ProjectId=1,
            SkillId=1
        },
        new ProjectSkill
        {
            Id=2,
            ProjectId=1,
            SkillId=2
        }
    };

    private readonly IProjectCRUD _projects;

    private readonly ISkillCRUD _skills;

    public ProjectSkillCRUD(IProjectCRUD projectCRUD, ISkillCRUD skillCRUD)
    {
        _projects = projectCRUD;
        _skills = skillCRUD;
    }

    public void Create(ProjectSkill entity)
    {
        var skill = _skills.GetById(entity.SkillId);
        var project = _projects.GetById(entity.ProjectId);
        
        if (project is null || skill is null) return;
        
        bool relationExists = _relations.Any(r => r.ProjectId == entity.ProjectId && r.SkillId == entity.SkillId);
       
        if (relationExists) return;
        
        entity.Id = _relations.Count > 0 ? _relations.Max(p => p.Id) + 1 : 1; // Auto-increment Id
        _relations.Add(entity);
    }

    public void Delete(int id)
    {
        var relation = _relations.FirstOrDefault(r => r.Id == id);
        if (relation is not null) _relations.Remove(relation);
        
    }
    private void CleanRelations()
    {
        var relationsToRemove = new List<ProjectSkill>();

        foreach (var relation in _relations) 
        {
            
            var project = _projects.GetById(relation.ProjectId);
            var skill = _skills.GetById(relation.SkillId);

            if (project is null || skill is null)
            {
                relationsToRemove.Add(relation);
            }
        }

        foreach (var relation in relationsToRemove)
        {
            _relations.Remove(relation);
        }
    }

    public IEnumerable<ProjectSkill> GetAll()
    {
        CleanRelations();
        return _relations;
    }

    public ProjectSkill? GetById(int id)
    {
        CleanRelations();
        return _relations.FirstOrDefault(r => r.Id == id);
    }

    public void Update(ProjectSkill entity)
    {
        var relation = _relations.FirstOrDefault(r => r.Id == entity.Id);
        if (relation is null) return;
    
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

     public IEnumerable<Project> GetProjects()
    {
        return _projects.GetAll();
    }

    public IEnumerable<Skill> GetSkills()
    {
        return _skills.GetAll();
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
                    skill.Projects = [];
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
                    project.Skills = [];
                    relatedProjects.Add(project);
                }
            }
        }

        return relatedProjects;
    }
}