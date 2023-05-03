using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.MVC.Models
{
    public class Interior
    {
        public int Id { get; set; }
        public string Interior_name { get; set; }
        public byte[] InteriorPicture { get; set; }
    }
}
