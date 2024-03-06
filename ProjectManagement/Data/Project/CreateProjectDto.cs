﻿using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Data.Project
{
    public class CreateProjectDto
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}