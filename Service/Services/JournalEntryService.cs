using AutoMapper;
using Data.IRepository;
using Data.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Service.DTOs.GoalDTOs;
using Service.DTOs.JournalEntryDTOs;
using Service.Helpers;
using Service.Interfaces;
using Service.Mappers;

namespace Service.Services;

public class JournalEntryService : IJournalEntryService
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    public JournalEntryService()
    {
        this.unitOfWork = new UnitOfWork();
        this.mapper = new Mapper(new MapperConfiguration(c => c.AddProfile<MappingProfile>()));
    }

    public async Task<Responce<JournalEntryResultDto>> AddAsync(JournalEntryCreationDto dto)
    {
        JournalEntry existEntry = await this.unitOfWork.JournalEntryRepository.SelectAll().FirstOrDefaultAsync(x => x.EntryText == dto.EntryText);
        if (existEntry is not null)
            return new Responce<JournalEntryResultDto>
            {
                StatusCode = 409,
                Message = "This entry allready exist"
            };

        JournalEntry entry = this.mapper.Map<JournalEntry>(dto);

        await this.unitOfWork.JournalEntryRepository.CreateAsync(entry);
        await this.unitOfWork.SaveAsync();

        var result = this.mapper.Map<JournalEntryResultDto>(entry);
        return new Responce<JournalEntryResultDto>()
        {
            StatusCode = 201,
            Message = "Created",
            Data = result
        };
    }

    public async Task<Responce<IEnumerable<JournalEntryResultDto>>> GetAllAsync()
    {
        var entries = await this.unitOfWork.JournalEntryRepository.SelectAll().ToListAsync();
        var result = this.mapper.Map<IEnumerable<JournalEntryResultDto>>(entries);

        return new Responce<IEnumerable<JournalEntryResultDto>>()
        {
            Data = result,
            StatusCode = 200,
            Message = "Ok"
        };
    }

    public async Task<Responce<JournalEntryResultDto>> GetByIdAsync(long id)
    {
        JournalEntry existEntry = await this.unitOfWork.JournalEntryRepository.SelectByIdAsync(id);
        if (existEntry is null)
            return new Responce<JournalEntryResultDto>
            {
                StatusCode = 404,
                Message = "This entry not found"
            }; // Is not found


        var result = this.mapper.Map<JournalEntryResultDto>(existEntry);

        return new Responce<JournalEntryResultDto>
        {
            Data = result,
            StatusCode = 200,
            Message = "ok"
        };
    }

    public async Task<Responce<JournalEntryResultDto>> ModifyAsync(JournalEntryUpdateDto dto)
    {
        JournalEntry existEntry = await this.unitOfWork.JournalEntryRepository.SelectByIdAsync(dto.Id);
        if (existEntry is null)
            return new Responce<JournalEntryResultDto>
            {
                StatusCode = 404,
                Message = "This entry not found"
            }; // Is not found

        var mappedEntry = this.mapper.Map(dto, existEntry);
        this.unitOfWork.JournalEntryRepository.Update(mappedEntry);
        await this.unitOfWork.SaveAsync();

        var result = this.mapper.Map<JournalEntryResultDto>(mappedEntry);
        return new Responce<JournalEntryResultDto>
        {
            Data = result,
            StatusCode = 200,
            Message = "ok"
        };
    }

    public async Task<Responce<bool>> RemoveAsync(long id)
    {
        JournalEntry existEntry = await this.unitOfWork.JournalEntryRepository.SelectByIdAsync(id);
        if (existEntry is null)
            return new Responce<bool>
            {
                StatusCode = 404,
                Message = "This entry not found",
                Data = false
            }; // Is not found

        this.unitOfWork.JournalEntryRepository.Delete(existEntry);
        await this.unitOfWork.SaveAsync();
        return new Responce<bool>
        {
            Data = true,
            StatusCode = 200,
            Message = "ok"
        };
    }
}
