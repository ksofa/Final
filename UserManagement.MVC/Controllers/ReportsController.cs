using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UserManagement.MVC.Data;
using UserManagement.MVC.Models;
using UserManagement.MVC.RepModels;

namespace UserManagement.MVC.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ReportsController : Controller
    {
        private ApplicationDbContext db;

        public ReportsController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        // GET: api/<ReportController>
        [HttpGet("admin {id}")]
        public IEnumerable<Report> Get(int id)
        {
            return db.Reports.Where(r => r.ProjectsId == id).ToList();
            //обработчики! 
        }
        // GET api/<ReportController>/5
        [HttpGet("{id}")]
        [Authorize]
        public IEnumerable<Report> GetReportbyProjectId(int id)
        {

             var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
           
            return db.Reports.Where(r => r.ProjectsId == id).ToList();
            
        }

        //// GET api/<ReportController>/5
        //[HttpGet("{id}")]
        //public Report Get(int id)
        //{
        //    Report proj = db.Reports.Find(id); 
        //    // throw new Exception("не найден пользователь");
        //    return proj;
        //}
        // DELETE api/<ReportController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Report proj = db.Reports.Find(id);
            if (proj == null)
            {
                throw new Exception("not found");
            }
            db.Reports.Remove(proj);
            db.SaveChanges();
            // throw new Exception("не найден пользователь");
            //return proj;
        }
        // POST api/<ReportController>
        [HttpPost]
        public Report Post(ReportsViewModel v)
        {
            
            var project = db.Projects.FirstOrDefault(u => u.Id == v.ProjectsId);
            var repo = new Report
            {
                ReportText = v.ReportText,
                CreatedAt = v.CreatedAt,
                Title = v.Title,
                ProjectsId = project.Id
            };

            if (repo.Id != 0)
            {
                var bdproj = db.Reports.Find(repo.Id);

                bdproj.ReportText = repo.ReportText;
                bdproj.CreatedAt = repo.CreatedAt;
            }

            if (ModelState.IsValid)
            {
                db.Reports.Add(repo);
                db.SaveChanges();
            }

            return repo;
        }
    }
}
