using Domain.Commons;

namespace Domain.Entities;

public class TaskUser:Auditable
{
    public long GoalId { get; set; }
    public string TaskName { get; set; }
    public string TaskDescription { get; set; }
    public DateTime DueDate { get; set; }
    public string Priority { get; set; }
    public string Status { get; set; }
    public Goal Goal { get; set; }
}
