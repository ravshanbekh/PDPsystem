using Service.DTOs.UserDTOs;

namespace Service.DTOs.JournalEntryDTOs;

public class JournalEntryResultDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public DateTime EntryDate { get; set; }
    public string EntryText { get; set; }
    public UserResultDto User { get; set; }
}
