using Service.DTOs.GoalDTOs;
using Service.DTOs.JournalEntryDTOs;

namespace Service.DTOs.UserDTOs;

public class UserResultDto
{
    public long Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string ProfilePicture { get; set; }
    public string Bio { get; set; }
    public List<GoalResultDto> Goals { get; set; }
    public List<JournalEntryResultDto> JournalEntries { get; set; }
}
