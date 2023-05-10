using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UserManagement.MVC.Models
{
    [Table("Project")]
    public class Project 
    {
        [Key]
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public uint Price { get; set; }
        public uint Area { get; set; }
        public string TypeProject { get; set; }
        public string Adress { get; set; }
        public string Status { get; set; }
        public string CreatedAt { get; set; }
        //[JsonIgnore]
        public ICollection<Report> Reports { get; set; } = new List<Report>();
        public ICollection<ProjectImage> ProjectImages { get; set; } = new List<ProjectImage>();
        [JsonIgnore]
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; } 

    }
}