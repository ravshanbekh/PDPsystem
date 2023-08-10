namespace Service.DTOs.GoalDTOs;

public class GoalCreationDto
{
    public long UserId { get; set; }
    public string GoalTitle { get; set; }
    public string GoalDescription { get; set; }
    public DateTime StartDate { get; set; }

    public DateTime DueDate { get; set; }
    public string Status { get; set; }
}
