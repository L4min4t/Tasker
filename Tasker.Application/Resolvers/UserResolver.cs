﻿using Tasker.Application.DTOs.Application.Project;
using Tasker.Application.DTOs.Application.ResolvedProperties;
using Tasker.Application.DTOs.Application.User;
using Tasker.Application.Interfaces.Resolvers;
using Tasker.Domain.Entities.Application;
using Tasker.Domain.Exceptions;
using Tasker.Domain.Repositories;
using Task = System.Threading.Tasks.Task;

namespace Tasker.Application.Resolvers;

public class UserResolver : IUserResolver
{
    private readonly IEntityRepository<User> _repository;
    private readonly IProjectResolver _resolver;

    public UserResolver(IProjectResolver resolver, IEntityRepository<User> repository)
    {
        _resolver = resolver;
        _repository = repository;
    }

    public async Task<User> ResolveAsync(string id)
        => await _repository.GetByIdAsync(id)
           ?? throw new InvalidEntityException($"The user with {id} was not found");

    public async Task ResolveAsync(List<UserProjectDto>? assigned,
        List<UserProjectDto>? admin, string userId)
    {
        if (assigned is not null)
        {
            await _resolver.ResolveAssignedProjectsAsync(p => p.UserId == userId && assigned.Select(dto => dto.ProjectId).Contains(p.ProjectId), assigned);
        }

        if (admin is not null)
        {
            await _resolver.ResolveAdminProjectsAsync(p => p.UserId == userId && admin.Select(dto => dto.ProjectId).Contains(p.ProjectId), admin);
        }
    }
}