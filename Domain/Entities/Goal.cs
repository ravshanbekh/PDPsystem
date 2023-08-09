namespace Domain.Entities;

public class Goal
{
    public long GoalId { get; set; }
    public long UserId { get; set; }
    public string GoalTitle { get; set; }
    public string GoalDescription { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime DueDate { get; set; }
    public string Status { get; set; }
    public User User { get; set; }
    public List<TaskUser> Tasks { get; set; }
}

