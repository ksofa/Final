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
            //var user = db.ApplicationUsers.FirstOrDefault(u => u.Id == v.ApplicationUserId);
            //var w =  db.Projects.Where(p => p.ApplicationUser.Id == userId);
           // var project = db.Projects.FindAsync(id);
            //   var project = db.Projects.Include(p => p.Reports).FirstOrDefaultAsync(p => p.Id == id && p.ApplicationUserId == userId);
            //foreach (var item in w)
            //{
            //   var b = item.Reports.ToList();
            //}
           // return
            return db.Reports.Where(r => r.ProjectsId == id).ToList();
            // return (IEnumerable<ProjectViewModel>)projects;
            // return db.Projects.Select(x => new ProjectViewModel { }).ToList();
            //обработчики! 
        }

        //// GET api/<ReportController>/5
        //[HttpGet("{id}")]
        //public Report Get(int id)
        //{
        //    Report proj = db.Reports.Find(id);
        //    // throw new Exception("не найден пользователь");
        //    return proj;
        //}

        // POST api/<ReportController>
        [HttpPost]
        public Report Post(ReportsViewModel v)
        {
            //var user = db.ApplicationUsers.FirstOrDefault(u => u.Id == v.ApplicationUserId);
            //var project = new Project
            //{
            //    ProjectName = v.ProjectName,
            //    Price = v.Price,
            //    Area = v.Area,
            //    Adress = v.Adress,
            //    CreatedAt = v.CreatedAt,
            //    Status = v.Status,
            //    ApplicationUserId = user.Id
            //};

            //if (project.Id != 0)
            //{
            //    var bdproj = db.Projects.Find(project.Id);

            //    bdproj.Price = project.Price;
            //    bdproj.Area = project.Area;
            //}

            //if (ModelState.IsValid)
            //{
            //    db.Projects.Add(project);
            //    db.SaveChanges();
            //}

            //return project;
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
