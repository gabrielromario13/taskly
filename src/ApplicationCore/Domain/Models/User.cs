using System.ComponentModel.DataAnnotations;
using ApplicationCore.Domain.Enums;

namespace ApplicationCore.Domain.Models;

public class User(string name, string username, string email, string password, Roles role, long? projectId)
    : BaseEntity
{
    public string Name { get; private set; } = name;
    public string Username { get; private set; } = username;
    public string Email { get; private set; } = email;
    public string Password { get; private set; } = password;
    public Roles Role { get; private set; } = role;
    public long? ProjectId { get; private set; } = projectId;
    public DateTime LastLogin { get; private set; }

    public void Update()
    {
        LastLogin = DateTime.UtcNow;
    }
}