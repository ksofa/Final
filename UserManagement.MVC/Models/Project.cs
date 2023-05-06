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
        public int Price { get; set; }
        public int Area { get; set; }
        public string Adress { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public ICollection<Report> Reports { get; set; } = new List<Report>();
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; } 

    }
}