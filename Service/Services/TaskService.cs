using AutoMapper;
using Data.IRepository;
using Data.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Service.DTOs.GoalDTOs;
using Service.DTOs.TaskDTOs;
using Service.Helpers;
using Service.Interfaces;
using Service.Mappers;

namespace Service.Services;

public class TaskService : ITaskService
{
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    public TaskService()
    {
        this.unitOfWork = new UnitOfWork();
        this.mapper = new Mapper(new MapperConfiguration(c => c.AddProfile<MappingProfile>()));
    }

    public async Task<Responce<TaskResultDto>> AddAsync(TaskCreationDto dto)
    {
        TaskUser existTask = await this.unitOfWork.TaskRepository.SelectAll().FirstOrDefaultAsync(x => x.TaskName == dto.TaskName);
        if (existTask is not null)
            return new Responce<TaskResultDto>
            {
                StatusCode = 409,
                Message = "This task allready exist"
            };

        TaskUser task = this.mapper.Map<TaskUser>(dto);

        await this.unitOfWork.TaskRepository.CreateAsync(task);
        await this.unitOfWork.SaveAsync();

        var result = this.mapper.Map<TaskResultDto>(task);
        return new Responce<TaskResultDto>()
        {
            StatusCode = 201,
            Message = "Created",
            Data = result
        };
    }

    public async Task<Responce<IEnumerable<TaskResultDto>>> GetAllAsync()
    {
        var tasks = await this.unitOfWork.TaskRepository.SelectAll().ToListAsync();
        var result = this.mapper.Map<IEnumerable<TaskResultDto>>(tasks);

        return new Responce<IEnumerable<TaskResultDto>>()
        {
            Data = result,
            StatusCode = 200,
            Message = "Ok"
        };
    }

    public async Task<Responce<TaskResultDto>> GetByIdAsync(long id)
    {
        TaskUser existTask = await this.unitOfWork.TaskRepository.SelectByIdAsync(id);
        if (existTask is null)
            return new Responce<TaskResultDto>
            {
                StatusCode = 404,
                Message = "This task not found"
            }; // Is not found


        var result = this.mapper.Map<TaskResultDto>(existTask);

        return new Responce<TaskResultDto>
        {
            Data = result,
            StatusCode = 200,
            Message = "ok"
        };
    }

    public async Task<Responce<TaskResultDto>> ModifyAsync(TaskUpdateDto dto)
    {
        TaskUser existTask = await this.unitOfWork.TaskRepository.SelectByIdAsync(dto.Id);
        if (existTask is null)
            return new Responce<TaskResultDto>
            {
                StatusCode = 404,
                Message = "This task not found"
            }; // Is not found

        var mappedTask = this.mapper.Map(dto, existTask);
        this.unitOfWork.TaskRepository.Update(mappedTask);
        await this.unitOfWork.SaveAsync();

        var result = this.mapper.Map<TaskResultDto>(mappedTask);
        return new Responce<TaskResultDto>
        {
            Data = result,
            StatusCode = 200,
            Message = "ok"
        };
    }

    public async Task<Responce<bool>> RemoveAsync(long id)
    {
        TaskUser existTask = await this.unitOfWork.TaskRepository.SelectByIdAsync(id);
        if (existTask is null)
            return new Responce<bool>
            {
                StatusCode = 404,
                Message = "This task not found",
                Data = false
            }; // Is not found

        this.unitOfWork.TaskRepository.Delete(existTask);
        await this.unitOfWork.SaveAsync();
        return new Responce<bool>
        {
            Data = true,
            StatusCode = 200,
            Message = "ok"
        };
    }
}
