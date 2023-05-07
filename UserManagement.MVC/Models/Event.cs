using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.MVC.Models
{
    public class Event
    {
        public int Id { get; set; }
        public DateTime Meeting { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int UserApplicationUserId { get; set; }
    }
}
