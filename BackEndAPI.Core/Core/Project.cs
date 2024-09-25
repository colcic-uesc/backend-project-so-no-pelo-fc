using System;
using System.Text.Json.Serialization;

namespace BackEndAPI.Core;

public class Project
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Type { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    [JsonIgnore]
    public IEnumerable<Skill>? Skills { get; set; }

}