namespace Service.DTOs.JournalEntryDTOs;

public class JournalEntryUpdateDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public DateTime EntryDate { get; set; }
    public string EntryText { get; set; }
}
