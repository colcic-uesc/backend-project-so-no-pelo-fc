using BackEndAPI.Core.Dtos.User;

namespace BackEndAPI.Core;

public class StudentUpdateDto
{
    public string? Registration { get; set; } 
    public string? Name { get ; set; } 
    public string? Email { get; set; } 
    public string? Course { get; set; } 
    public string? Bio { get; set; } 
    public UserGetDto User { get; set; } = null!;
}