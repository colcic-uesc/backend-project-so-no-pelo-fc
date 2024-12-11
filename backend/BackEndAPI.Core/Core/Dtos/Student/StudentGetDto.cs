using BackEndAPI.Core.Dtos;
using BackEndAPI.Core.Dtos.User;

namespace BackEndAPI.Core;

public class StudentGetDto
{
    public int? Id { get; set; }
    public string? Registration { get; set; } 
    public string? Name { get ; set; } 
    public string? Email { get; set; } 
    public string? Course { get; set; } 
    public string? Bio { get; set; } 
    public UserGetDto? User { get; set;}
}