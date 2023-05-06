using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagement.MVC.Data;
using UserManagement.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using UserManagement.MVC.RepModels;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManagement.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProjectController : Controller
    {
        private ApplicationDbContext db;

        public ProjectController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        //// GET: api/<ProjectController>
        //[HttpGet]
        //[AllowAnonymous]
        //public IEnumerable<ProjectViewModel> Get()
        //{
        //    return db.Projects.Select(x => new ProjectViewModel { }).ToList();
        //    //обработчики! 
        //}
        
        // GET: api/<ProjectController>
        [HttpGet]
        [Authorize]
        public IEnumerable<ProjectViewModel> Get()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var projects = db.Projects.Where(p => p.ApplicationUser.Id == userId).ToList();

            return (IEnumerable<ProjectViewModel>)Ok(projects);
            // return db.Projects.Select(x => new ProjectViewModel { }).ToList();
            //обработчики! 
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public Project Get(int id)
        {
            Project proj = db.Projects.Find(id);
           // throw new Exception("не найден пользователь");
            return proj;
        }

        // POST api/<ProjectController>
        [HttpPost]
        public Project Post(ProjectViewModel v)
        {

            var user = db.ApplicationUsers.FirstOrDefault(u => u.Id == v.ApplicationUserId);
            var project = new Project
            {
                ProjectName = v.ProjectName,
                Price = v.Price,
                Area = v.Area,
                Adress = v.Adress,
                CreatedAt = v.CreatedAt,
                Status = v.Status,
                ApplicationUser = user
            };

            if (project.Id != 0)
            {
                var bdproj = db.Projects.Find(project.Id);

                bdproj.Price = project.Price;
                bdproj.Area = project.Area;
            }

            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
            }

            return project;
        }
    }
}
