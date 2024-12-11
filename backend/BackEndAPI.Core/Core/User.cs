using System;

namespace BackEndAPI.Core;

public class User
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Rules { get; set; }
    public Professor? Professor { get; set; }
    public Student? Student { get; set; }
}