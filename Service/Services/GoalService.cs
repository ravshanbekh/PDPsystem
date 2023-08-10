using AutoMapper;
using Data.IRepository;
using Data.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Service.DTOs.GoalDTOs;
using Service.DTOs.UserDTOs;
using Service.Helpers;
using Service.Interfaces;
using Service.Mappers;

namespace Service.Services;

public class GoalService : IGoalService
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    public GoalService()
    {
        this.unitOfWork = new UnitOfWork();
        this.mapper = new Mapper(new MapperConfiguration(c => c.AddProfile<MappingProfile>()));
    }

    public async Task<Responce<GoalResultDto>> AddAsync(GoalCreationDto dto)
    {
        Goal existGoal = await this.unitOfWork.GoalRepository.SelectAll().FirstOrDefaultAsync(x => x.GoalTitle == dto.GoalTitle);
        if (existGoal is not null)
            return new Responce<GoalResultDto>
            {
                StatusCode = 409,
                Message = "This user allready exist"
            };

        Goal goal = this.mapper.Map<Goal>(dto);

        await this.unitOfWork.GoalRepository.CreateAsync(goal);
        await this.unitOfWork.SaveAsync();

        var result = this.mapper.Map<GoalResultDto>(goal);
        return new Responce<GoalResultDto>()
        {
            StatusCode = 201,
            Message = "Created",
            Data = result
        };
    }

    public async Task<Responce<IEnumerable<GoalResultDto>>> GetAllAsync()
    {
        var goals = await this.unitOfWork.GoalRepository.SelectAll().ToListAsync();
        var result = this.mapper.Map<IEnumerable<GoalResultDto>>(goals);

        return new Responce<IEnumerable<GoalResultDto>>()
        {
            Data = result,
            StatusCode = 200,
            Message = "Ok"
        };
    }

    public async Task<Responce<GoalResultDto>> GetByIdAsync(long id)
    {
        Goal existGoal = await this.unitOfWork.GoalRepository.SelectByIdAsync(id);
        if (existGoal is null)
            return new Responce<GoalResultDto>
            {
                StatusCode = 404,
                Message = "This goal not found"
            }; // Is not found


        var result = this.mapper.Map<GoalResultDto>(existGoal);

        return new Responce<GoalResultDto>
        {
            Data = result,
            StatusCode = 200,
            Message = "ok"
        };
    }

    public async Task<Responce<GoalResultDto>> ModifyAsync(GoalUpdateDto dto)
    {
        Goal existGoal = await this.unitOfWork.GoalRepository.SelectByIdAsync(dto.Id);
        if (existGoal is null)
            return new Responce<GoalResultDto>
            {
                StatusCode = 404,
                Message = "This goal not found"
            }; // Is not found

        var mappedGoal = this.mapper.Map(dto, existGoal);
        this.unitOfWork.GoalRepository.Update(mappedGoal);
        await this.unitOfWork.SaveAsync();

        var result = this.mapper.Map<GoalResultDto>(mappedGoal);
        return new Responce<GoalResultDto>
        {
            Data = result,
            StatusCode = 200,
            Message = "ok"
        };
    }

    public async Task<Responce<bool>> RemoveAsync(long id)
    {
        Goal existGoal = await this.unitOfWork.GoalRepository.SelectByIdAsync(id);
        if (existGoal is null)
            return new Responce<bool>
            {
                StatusCode = 404,
                Message = "This goal not found",
                Data = false
            }; // Is not found

        this.unitOfWork.GoalRepository.Delete(existGoal);
        await this.unitOfWork.SaveAsync();
        return new Responce<bool>
        {
            Data = true,
            StatusCode = 200,
            Message = "ok"
        };
    }
}
