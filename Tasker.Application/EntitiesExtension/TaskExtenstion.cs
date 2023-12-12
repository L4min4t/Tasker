﻿using Tasker.Application.DTOs.Application.Task;
using Tasker.Application.Resolvers.DTOs;
using Task = Tasker.Domain.Entities.Application.Task;

namespace Tasker.Application.EntitiesExtension;

public static class TaskExtenstion
{
    public static void Update(this Task task, TaskUpdateDto updateDto,
        TaskResolvedPropertiesDto resolvedProperties)
    {
        task.Title = updateDto.Title ?? task.Title;
        task.Description = updateDto.Description ?? task.Description;
        
        task.Priority = updateDto.Priority ?? task.Priority;
        
        task.Project = resolvedProperties.Project ?? task.Project;
        task.ProjectId = resolvedProperties.Project?.Id ?? task.ProjectId;
        
        task.Assignee = resolvedProperties.Assignee ?? task.Assignee;
        task.AssigneeId = resolvedProperties.Assignee?.Id ?? task.AssigneeId;
        
        task.Creator = resolvedProperties.Creator ?? task.Creator;
        task.CreatorId = resolvedProperties.Creator?.Id ?? task.CreatorId;
        
        task.Status = resolvedProperties.Status ?? task.Status;
        task.TaskStatusId = resolvedProperties.Status?.Id ?? task.TaskStatusId;
        
        task.Release = resolvedProperties.Release ?? task.Release;
        task.ReleaseId = resolvedProperties.Release?.Id ?? task.ReleaseId;
    }
}