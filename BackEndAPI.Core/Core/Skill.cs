using System;
using System.Text.Json.Serialization;

namespace BackEndAPI.Core;

public class Skill
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    [JsonIgnore] // Prevents Swagger from including this in request body
    public List<Project>? Projects { get; set; }
}