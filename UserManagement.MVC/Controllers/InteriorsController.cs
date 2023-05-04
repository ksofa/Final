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
    public class InteriorsController : Controller
    {
        private ApplicationDbContext db;

        public InteriorsController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        // GET: api/<InteriorController>
        [HttpGet]
        public IEnumerable<Interior> Get()
        {
            return db.Interior.ToList();
        }

        // GET api/<InteriorController>/5
        [HttpGet("{id}")]
        public Interior Get(int id)
        {
            Interior n = db.Interior.Find(id);
            return n;
        }

        // POST api/<NewsController>
        [HttpPost]
        public Interior Post(Interior n)
        {
            if (n.Id != 0)
            {
                Interior bdn = db.Interior.Find(n.Id);
                bdn.Interior_name = n.Interior_name;
            }

            if (ModelState.IsValid)
            {
                db.Interior.Add(n);
                db.SaveChanges();
            }

            return n;
        }
    }
}
