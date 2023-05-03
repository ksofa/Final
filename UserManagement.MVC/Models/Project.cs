using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.MVC.Models
{
    [Table("Project")]
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public int Price { get; set; }
        public int Area { get; set; }
        public string Adress { get; set; }

        public News News { get; set; }
    }
}
