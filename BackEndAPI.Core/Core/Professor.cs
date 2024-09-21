using System;

namespace BackEndAPI.Core;

public class Professor 
{
    public int Id { get ; set; }
    public string? Name { get ; set; } 
    public string? Email { get; set; } 
    public string? Department { get; set; } 
    public string? Bio { get; set; } 
}