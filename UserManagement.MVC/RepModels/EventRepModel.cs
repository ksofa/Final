using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.MVC.RepModels
{
    public class EventRepModel
    {
        public int Id { get; set; }
        public string TitleMeeting { get; set; }
        public string Meeting { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
