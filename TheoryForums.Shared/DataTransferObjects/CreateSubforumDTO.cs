﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheoryForums.Shared.DataTransferObjects
{
    public class CreateSubforumDTO
    {
        [Required] public int ForumId { get; set; }
        [Required] public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
