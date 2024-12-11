
using BackEndAPI.Core.Dtos.User;

namespace BackEndAPI.Core;

public class StudentCreateDto
{
    public string? Registration { get; set; } 
    public string? Name { get ; set; } 
    public string? Email { get; set; } 
    public string? Course { get; set; } 
    public string? Bio { get; set; } 
    public UserCreateDto User { get; set; } = null!;
}