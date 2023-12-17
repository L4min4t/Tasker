﻿using AutoMapper;
using Tasker.Application.DTOs.Application.KanbanBoard;
using Tasker.Application.DTOs.Application.Project;
using Tasker.Application.DTOs.Application.Release;
using Tasker.Application.DTOs.Application.Task;
using Tasker.Application.DTOs.Application.TaskStatus;
using Tasker.Application.DTOs.Application.User;
using Tasker.Domain.Entities.Application;
using Task = Tasker.Domain.Entities.Application.Task;
using TaskStatus = Tasker.Domain.Entities.Application.TaskStatus;

namespace Tasker.Application.MappingProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Project, ProjectDto>()
            .ForMember(t => t.KanbanBoards, src => src.MapFrom(t => t.KanbanBoards.Select(val => new KanbanBoardDto
            {
                Id = val.Id,
                Title = val.Title
            })))
            .ForMember(t => t.Tasks, src => src.MapFrom(t => t.Tasks.Select(val => new TaskDto
            {
                Id = val.Id,
                Title = val.Title!,
                ProjectId = t.Id,
                Creator = new UserDto
                {
                    Id = val.Creator.Id
                }
            })))
            .ForMember(t => t.Releases, src => src.MapFrom(t => t.Releases.Select(val => new ReleaseDto
            {
                Id = val.Id,
                Title = val.Title
            })));

        CreateMap<KanbanBoard, KanbanBoardDto>().ForMember(dest => dest.Columns, opt => opt.MapFrom(src =>
            src.Columns.Select(t => new TaskStatusDto
            {
                Id = t.Id,
                Name = t.Name
            })));
        CreateMap<KanbanBoardUpdateDto, KanbanBoard>();

        CreateMap<Release, ReleaseDto>()
            .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks.Select(t => new TaskPreviewDto
            {
                Id = t.Id,
                Title = t.Title!,
                TaskStatusName = t.Status != null ? t.Status.Name : string.Empty
            })));
        CreateMap<Release, ReleaseCreateDto>().ReverseMap();

        CreateMap<User, UserDto>().ReverseMap();

        CreateMap<Task, TaskDto>()
            .ForMember(t => t.ProjectId, dto => dto.MapFrom(t => t.Project!.Id))
            .ForMember(t => t.Creator, dto => dto.MapFrom(t => t.Creator))
            .ForMember(t => t.Assignee, dto => dto.MapFrom(t => t.Assignee))
            .ForMember(t => t.TaskStatusId, dto => dto.MapFrom(t => t.Status != null ? t.Status.Id : null))
            .ForMember(t => t.ReleaseId, dto => dto.MapFrom(t => t.Release != null ? t.Release.Id : null));

        // Task Status
        CreateMap<TaskStatus, TaskStatusCreateDto>().ReverseMap();
        CreateMap<TaskStatus, TaskStatusDto>()
            .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks.Select(t => new TaskPreviewDto
            {
                Id = t.Id,
                Title = t.Title!,
                TaskStatusName = src.Name
            })));
    }
}