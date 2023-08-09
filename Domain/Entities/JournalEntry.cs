using Domain.Commons;

namespace Domain.Entities;

public class JournalEntry:Auditable
{
    public long UserId { get; set; }
    public DateTime EntryDate { get; set; }
    public string EntryText { get; set; }
    public User User { get; set; }
}
