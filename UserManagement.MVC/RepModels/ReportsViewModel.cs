using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.MVC.RepModels
{
    public class ReportsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ReportText { get; set; }
        // public byte[] ReportPicture { get; set; }
        public string CreatedAt { get; set; }
        public int ProjectsId { get; set; }
    }
}
