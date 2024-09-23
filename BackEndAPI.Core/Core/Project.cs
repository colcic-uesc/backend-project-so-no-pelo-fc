using System;

namespace BackEndAPI.Core;

public class Project 
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Type { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    //public List<Skill> Skills { get; set; }
}