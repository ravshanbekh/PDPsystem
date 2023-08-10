using AutoMapper;
using Data.IRepository;
using Data.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Service.DTOs.GoalDTOs;
using Service.DTOs.JournalEntryDTOs;
using Service.DTOs.UserDTOs;
using Service.Helpers;
using Service.Interfaces;
using Service.Mappers;

namespace Service.Services;

public class UserService : IUserService
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    public UserService()
    {
        this.unitOfWork = new UnitOfWork();
        this.mapper = new Mapper(new MapperConfiguration(c => c.AddProfile<MappingProfile>()));
    }

    public async Task<Responce<UserResultDto>> AddAsync(UserCreationDto dto)
    {
        User existUser = await this.unitOfWork.UserRepository.SelectAll().FirstOrDefaultAsync(x => x.Email == dto.Email);
        if (existUser is not null)
            return new Responce<UserResultDto>
            {
                StatusCode = 409,
                Message = "This user allready exist"
            };

        User user = this.mapper.Map<User>(dto);

        await this.unitOfWork.UserRepository.CreateAsync(user);
        await this.unitOfWork.SaveAsync();

        var listGoals = user.Goals.Select(x => this.mapper.Map<GoalResultDto>(x));
        var listEntry = user.JournalEntries.Select(x => this.mapper.Map<JournalEntryResultDto>(x));
        var result = this.mapper.Map<UserResultDto>(user);

        result.Goals = listGoals.ToList();
        result.JournalEntries = listEntry.ToList();

        return new Responce<UserResultDto>()
        {
            StatusCode = 201,
            Message = "Created",
            Data = result
        };
    }

    public Task<Responce<IEnumerable<UserResultDto>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Responce<UserResultDto>> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Responce<UserResultDto>> ModifyAsync(UserUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<Responce<bool>> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }
}
