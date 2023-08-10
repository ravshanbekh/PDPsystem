using Service.DTOs.TaskDTOs;
using Service.Helpers;
using Service.Interfaces;

namespace Service.Services;

public class TaskService : ITaskService
{
    public Task<Responce<TaskResultDto>> AddAsync(TaskCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<Responce<IEnumerable<TaskResultDto>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Responce<TaskResultDto>> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Responce<TaskResultDto>> ModifyAsync(TaskUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<Responce<bool>> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }
}
