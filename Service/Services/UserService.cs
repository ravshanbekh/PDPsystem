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

        //var listGoals = user.Goals.Select(x => this.mapper.Map<GoalResultDto>(x));
        //var listEntry = user.JournalEntries.Select(x => this.mapper.Map<JournalEntryResultDto>(x));
        var result = this.mapper.Map<UserResultDto>(user);

        //result.Goals = listGoals.ToList();
        //result.JournalEntries = listEntry.ToList();

        return new Responce<UserResultDto>()
        {
            StatusCode = 201,
            Message = "Created",
            Data = result
        };
    }

    public async Task<Responce<IEnumerable<UserResultDto>>> GetAllAsync()
    {
        var users = await this.unitOfWork.UserRepository.SelectAll().ToListAsync();
        var result = this.mapper.Map<IEnumerable<UserResultDto>>(users);

        return new Responce<IEnumerable<UserResultDto>>()
        {
            Data=result,
            StatusCode = 200,
            Message="Ok"
        };
    }

    public async Task<Responce<UserResultDto>> GetByIdAsync(long id)
    {
        User existUser = await this.unitOfWork.UserRepository.SelectByIdAsync(id);
        if (existUser is null)
            return new Responce<UserResultDto>
            {
                StatusCode=404,
                Message="This user not found"
            }; // Is not found

        
        var result = this.mapper.Map<UserResultDto>(existUser);

        return new Responce<UserResultDto>
        {
            Data = result,
            StatusCode = 200,
            Message="ok"
        };
    }

    public async Task<Responce<UserResultDto>> ModifyAsync(UserUpdateDto dto)
    {
        User existUser = await this.unitOfWork.UserRepository.SelectAll().FirstOrDefaultAsync(x=>x.Id == dto.Id);
        if (existUser is null)
            return new Responce<UserResultDto>
            {
                StatusCode = 404,
                Message = "This user not found"
            }; // Is not found

        var mappedUser = this.mapper.Map(dto, existUser);
        this.unitOfWork.UserRepository.Update(mappedUser);
        await this.unitOfWork.SaveAsync();

        var result = this.mapper.Map<UserResultDto>(mappedUser);
        return new Responce<UserResultDto>
        {
            Data= result,
            StatusCode = 200,
            Message="ok"
        };
    }

    public async Task<Responce<bool>> RemoveAsync(long id)
    {
        User existUser = await this.unitOfWork.UserRepository.SelectByIdAsync(id);
        if (existUser is null)
            return new Responce<bool>
            {
                StatusCode = 404,
                Message = "This user not found",
                Data=false
            }; // Is not found

        this.unitOfWork.UserRepository.Delete(existUser);
        await this.unitOfWork.SaveAsync();
        return new Responce<bool>
        {
            Data=true,
            StatusCode = 200,
            Message="ok"
        };
    }
}
