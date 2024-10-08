namespace BackEndAPI.Core;

public class Skill
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public ICollection<Project> Projects { get; set; } = [];
}