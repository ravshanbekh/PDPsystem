using Service.DTOs.GoalDTOs;
using Service.Helpers;

namespace Service.Interfaces;

public interface IGoalService
{
    Task<Responce<GoalResultDto>> AddAsync(GoalCreationDto dto);
    Task<Responce<GoalResultDto>> ModifyAsync(GoalUpdateDto dto);
    Task<Responce<bool>> RemoveAsync(long id);
    Task<Responce<GoalResultDto>> GetByIdAsync(long id);
    Task<Responce<IEnumerable<GoalResultDto>>> GetAllAsync();
}
