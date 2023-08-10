namespace Service.DTOs.JournalEntryDTOs;

public class JournalEntryCreationDto
{
    public long UserId { get; set; }
    public DateTime EntryDate { get; set; }
    public string EntryText { get; set; }
}
