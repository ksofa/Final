using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.MVC.Data;
using UserManagement.MVC.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserManagement.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private ApplicationDbContext db;

        public NewsController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        // GET: api/<NewsController>
        [HttpGet]
        public IEnumerable<News> Get()
        {
            return db.News.ToList();
        }

        // GET api/<NewsController>/5
        [HttpGet("{id}")]
        public News Get(int id)
        {
            News n = db.News.Find(id);
            return n;
        }

        // POST api/<NewsController>
        [HttpPost]
        public News Post(News n)
        {
            if (n.Id != 0)
            {
                News bdn = db.News.Find(n.Id);
                bdn.Text = n.Text;
            }

            if (ModelState.IsValid)
            {
                db.News.Add(n);
                db.SaveChanges();
            }

            return n;
        }
    }
}
