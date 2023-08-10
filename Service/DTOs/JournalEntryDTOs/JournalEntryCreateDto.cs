namespace Service.DTOs.JournalEntryDTOs;

public class JournalEntryCreateDto
{
    public long UserId { get; set; }
    public DateTime EntryDate { get; set; }
    public string EntryText { get; set; }
}
