using System;

namespace BackEndAPI.Core;

public class Students
{
    public int Id { get ; set; }
    public string? Registration { get; set; }
    public string? Name { get ; set; }
    public string? Email { get; set; }
    public string? Course { get; set; }
    public string? Bio { get; set; }
    //public List<Skill> Skills { get; set; }
}