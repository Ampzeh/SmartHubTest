﻿using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class BaseModel
    {
        [Key]
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}