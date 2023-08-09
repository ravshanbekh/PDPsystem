using Domain.Commons;

namespace Domain.Entities;

public class User:Auditable
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ProfilePicture { get; set; }
    public string Bio { get; set; }
    public List<Goal> Goals { get; set; }
    public List<JournalEntry> JournalEntries { get; set; }
}
