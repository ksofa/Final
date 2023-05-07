using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UserManagement.MVC.Data;
using UserManagement.MVC.Models;

namespace UserManagement.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
  
            private ApplicationDbContext db;

            public EventController(ApplicationDbContext dbContext)
            {
                db = dbContext;
            }

        //// GET: api/<EventController>
        //[HttpGet]
        //[AllowAnonymous]
        //public IEnumerable<ProjectViewModel> Get()
        //{
        //    return db.Projects.Select(x => new ProjectViewModel { }).ToList();
        //    //
        //}

        //// GET: api/<EventController>
        //[HttpGet]
        //    [Authorize]
        //    public IEnumerable<Event> Get()
        //    {
        //        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //        return db.Events.Where(p => p.ApplicationUser.Id == userId).ToList();

        //        // return (IEnumerable<ProjectViewModel>)projects;
        //        // return db.Projects.Select(x => new ProjectViewModel { }).ToList();
        //        //обработчики! 
        //    }

        // GET api/<EventController>/5
        [HttpGet("{id}")]
            public Event Get(int id)
            {
            Event ev = db.Events.Find(id);
                // throw new Exception("не найден пользователь");
                return ev;
            }

        // POST api/<ProjectController>
        [HttpPost]
        public Event Post(Event v)
        {

            if (v.Id != 0)
            {
                var bdproj = db.Events.Find(v.Id);

                bdproj.Meeting = v.Meeting;
            }

            if (ModelState.IsValid)
            {
                db.Events.Add(v);
                db.SaveChanges();
            }

            return v;
        }
    }
}
