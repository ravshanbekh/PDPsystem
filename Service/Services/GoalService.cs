using Service.DTOs.GoalDTOs;
using Service.Helpers;
using Service.Interfaces;

namespace Service.Services;

public class GoalService : IGoalService
{
    public Task<Responce<GoalResultDto>> AddAsync(GoalCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<Responce<IEnumerable<GoalResultDto>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Responce<GoalResultDto>> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Responce<GoalResultDto>> ModifyAsync(GoalUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<Responce<bool>> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }
}
