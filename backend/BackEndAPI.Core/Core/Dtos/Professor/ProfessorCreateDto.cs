using BackEndAPI.Core.Dtos.User;

namespace BackEndAPI.Core.Dtos.Professor;

public class ProfessorCreateDto 
{
    public string? Name { get ; set; } 
    public string? Email { get; set; } 
    public string? Department { get; set; } 
    public string? Bio { get; set; } 
    public UserCreateDto User { get; set; } = null!;
}