using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.MVC.Models;

namespace UserManagement.MVC.RepModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public int Price { get; set; }
        public int Area { get; set; }
        public string Adress { get; set; }
        public string Status { get; set; } = "Preparing";
       // public byte[] ProjectPicture { get; set; }
       // public byte[] IconId { get; set; }
        public DateTime CreatedAt { get; set; }
        //public ApplicationUser ApplicationUsers { get; set; }
        public string ApplicationUserId { get; set; } 
        //public byte[] Image { get; set; }
    }
}
