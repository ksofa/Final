﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UserManagement.MVC.Models
{
    public class ProjectImage
    {
        public int Id { get; set; }
        //   public string Text { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedAt { get; set; }
        //public int ProjectsId { get; set; }
        // [JsonIgnore]
        public Project Projects { get; set; }
    }
}
