using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.MVC.Models
{
    public class Proposal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string ProjectName { get; set; }
        public string TypeProject { get; set; }
        public uint TotalArea { get; set; }
        public uint Budget { get; set; }
        public string City { get; set; }
    }
}
