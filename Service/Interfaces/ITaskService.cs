using Service.DTOs.TaskDTOs;
using Service.Helpers;

namespace Service.Interfaces;

public interface ITaskService
{
    Task<Responce<TaskResultDto>> AddAsync(TaskCreationDto dto);
    Task<Responce<TaskResultDto>> ModifyAsync(TaskUpdateDto dto); 
    Task<Responce<bool>> RemoveAsync(long id);
    Task<Responce<TaskResultDto>> GetByIdAsync(long id); 
    Task<Responce<IEnumerable<TaskResultDto>>> GetAllAsync();
}
