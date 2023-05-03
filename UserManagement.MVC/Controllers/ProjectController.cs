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

        // GET: api/<ProjectController>
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Project> Get()
        {
            return db.Projects.ToList();
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
        public Project Post(Project project)
        {
            if (project.Id != 0)
            {
                var bdproj = db.Projects.Find(project.Id);

                bdproj.Price = project.Price;
                bdproj.Area = project.Area;
            } 

            if(ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
            }

            return project;
        }
    }
}
