﻿using Tasker.Domain.Enums;

namespace Tasker.Application.DTOs.Application.Task;

public class TaskUpdateDto
{
    public required string Id { get; set; }
    public string? Title { get; set; }
    public ProjectDto? Project { get; set; }
    public UserDto? Creator { get; set; }
    public string? Description { get; set; }
    public TaskStatusDto? Status { get; set; }
    public ReleaseDto? Release { get; set; }
    public UserDto? Assignee { get; set; }
    public TaskPriority? Priority { get; set; }
}