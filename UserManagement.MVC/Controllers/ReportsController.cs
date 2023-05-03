using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UserManagement.MVC.Data;
using UserManagement.MVC.Models;

namespace UserManagement.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : Controller
    {
        private ApplicationDbContext db;

        public ReportsController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        // GET: api/<ReportController>
        [HttpGet]
        public IEnumerable<Report> Get()
        {
            return db.Reports.ToList();
            //обработчики! 
        }

        // GET api/<ReportController>/5
        [HttpGet("{id}")]
        public Report Get(int id)
        {
            Report proj = db.Reports.Find(id);
            // throw new Exception("не найден пользователь");
            return proj;
        }

        // POST api/<ProjectController>
        [HttpPost]
        public Report Post(Report rep)
        {
            if (rep.Id != 0)
            {
                var bdproj = db.Reports.Find(rep.Id);

                bdproj.ReportText = rep.ReportText;
            }

            if (ModelState.IsValid)
            {
                db.Reports.Add(rep);
                db.SaveChanges();
            }

            return rep;
        }
    }
}
