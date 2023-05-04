using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.MVC.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public byte[] NewsPicture { get; set; }
        public byte[] IconId { get; set; }
        public DateTime CreatedAt { get; set; } 
    }
}
