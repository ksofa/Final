using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UserManagement.MVC.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ReportText { get; set; }
       // public byte[] ReportPicture { get; set; }
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public int ProjectsId { get; set; }
        [JsonIgnore]
        public Project Projects { get; set; }
    }
}
