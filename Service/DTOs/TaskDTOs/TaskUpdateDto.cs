namespace Service.DTOs.TaskDTOs;

public class TaskUpdateDto
{
    public long Id { get; set; }
    public long GoalId { get; set; }
    public string TaskName { get; set; }
    public string TaskDescription { get; set; }
    public DateTime DueDate { get; set; }
    public string Priority { get; set; }
    public string Status { get; set; }
}
