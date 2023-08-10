using Service.DTOs.GoalDTOs;

namespace Service.DTOs.TaskDTOs;

public class TaskResultDto
{
    public long Id { get; set; }
    public long GoalId { get; set; }
    public string TaskName { get; set; }
    public string TaskDescription { get; set; }
    public DateTime DueDate { get; set; }
    public string Priority { get; set; }
    public string Status { get; set; }
    public GoalResultDto Goal { get; set; }
}
