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
using UserManagement.MVC.RepModels;

namespace UserManagement.MVC.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class EventController : ControllerBase
    {

        private ApplicationDbContext db;

        public EventController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        // GET: api/<EventController>
        [HttpGet("admin")]
        [AllowAnonymous]
        public IEnumerable<Event> Get()
        {
            return db.Events.ToList();
        }

        // GET: api/<EventController>
        [HttpGet]
        [Authorize]
        public IEnumerable<Event> GetEvents()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return db.Events.Where(p => p.ApplicationUser.Id == userId).ToList();
        }

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public Event Get(int id)
        {
            Event ev = db.Events.Find(id);
            return ev;
        }
        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Event proj = db.Events.Find(id);
            if (proj == null)
            {
                throw new Exception("not found");
            }
            db.Events.Remove(proj);
            db.SaveChanges();
            // throw new Exception("не найден пользователь");
            //return proj;
        }
        // POST api/<EventController>
        [HttpPost]
        [Authorize]
        public Event Post(EventRepModel v)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var ev = new Event
            {
                TitleMeeting = v.TitleMeeting,
                Meeting = v.Meeting,
                ApplicationUserId = userId
            };
            if (v.Id != 0)
            {
                var bdproj = db.Events.Find(v.Id);

                bdproj.Meeting = v.Meeting;
            }

            if (ModelState.IsValid)
            {
                db.Events.Add(ev);
                db.SaveChanges();
            }

            return ev;
        }
    }
}
