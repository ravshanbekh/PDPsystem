using Service.DTOs.TaskDTOs;
using Service.DTOs.UserDTOs;

namespace Service.DTOs.GoalDTOs;

public class GoalResultDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public string GoalTitle { get; set; }
    public string GoalDescription { get; set; }
    public DateTime StartDate { get; set; }

    public DateTime DueDate { get; set; }
    public string Status { get; set; }
    public UserResultDto User { get; set; }
    public List<TaskResultDto> Tasks { get; set; }
}
