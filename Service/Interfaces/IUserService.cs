using Service.DTOs.UserDTOs;
using Service.Helpers;

namespace Service.Interfaces;

public interface IUserService
{
    Task<Responce<UserResultDto>> AddAsync(UserCreationDto dto);
    Task<Responce<UserResultDto>> ModifyAsync(UserUpdateDto dto);
    Task<Responce<bool>> RemoveAsync(long id);
    Task<Responce<UserResultDto>> GetByIdAsync(long id);
    Task<Responce<IEnumerable<UserResultDto>>> GetAllAsync();
}
