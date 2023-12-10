﻿using Tasker.Domain.Entities.Application;

namespace Tasker.Application.DTOs
{
    public class ReleaseDto
    {
        public string? Id { get; set; }
        public string Title { get; set; }
        public bool? IsReleased { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime EndDate { get; set; }

        public string ProjectId { get; set; }
    }
}
