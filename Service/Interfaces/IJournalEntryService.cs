using Service.DTOs.JournalEntryDTOs;
using Service.Helpers;

namespace Service.Interfaces;

public interface IJournalEntryService
{
    Task<Responce<JournalEntryResultDto>> AddAsync(JournalEntryCreationDto dto);
    Task<Responce<JournalEntryResultDto>> ModifyAsync(JournalEntryUpdateDto dto);
    Task<Responce<bool>> RemoveAsync(long id);
    Task<Responce<JournalEntryResultDto>> GetByIdAsync(long id);
    Task<Responce<IEnumerable<JournalEntryResultDto>>> GetAllAsync();
}
