using AutoMapper;
using Domain.Entities;
using Service.DTOs.GoalDTOs;
using Service.DTOs.JournalEntryDTOs;
using Service.DTOs.TaskDTOs;
using Service.DTOs.UserDTOs;

namespace Service.Mappers;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserCreationDto>().ReverseMap();
        CreateMap<UserUpdateDto, User>().ReverseMap();
        CreateMap<UserResultDto, User>().ReverseMap();

        CreateMap<Goal, GoalCreationDto>().ReverseMap();
        CreateMap<GoalUpdateDto, Goal>().ReverseMap();
        CreateMap<GoalResultDto, Goal>().ReverseMap();

        CreateMap<TaskUser, TaskCreationDto>().ReverseMap();
        CreateMap<TaskUpdateDto, TaskUser>().ReverseMap();
        CreateMap<TaskResultDto, TaskUser>().ReverseMap();

        CreateMap<JournalEntry, JournalEntryCreationDto>().ReverseMap();
        CreateMap<JournalEntryUpdateDto, JournalEntry>().ReverseMap();
        CreateMap<JournalEntryResultDto, JournalEntry>().ReverseMap();
    }
}
