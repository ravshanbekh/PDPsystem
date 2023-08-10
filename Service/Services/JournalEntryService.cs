using Service.DTOs.JournalEntryDTOs;
using Service.Helpers;
using Service.Interfaces;

namespace Service.Services;

public class JournalEntryService : IJournalEntryService
{
    public Task<Responce<JournalEntryResultDto>> AddAsync(JournalEntryCreationDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<Responce<IEnumerable<JournalEntryResultDto>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Responce<JournalEntryResultDto>> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Responce<JournalEntryResultDto>> ModifyAsync(JournalEntryUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<Responce<bool>> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }
}
