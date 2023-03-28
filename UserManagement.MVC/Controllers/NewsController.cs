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
    [Route("news")]
    public class NewsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public object GetNews(int skip, int take)
        {
            return _context.News.Skip(skip).Take(take).ToArray();
        }

        [HttpPut]
        public object CreateNews([FromBody] News news)
        {
            var newNews = new News()
            {
                Text = news.Text
            };

            _context.News.Add(newNews);
            _context.SaveChanges();

            return newNews;
        }
    }
}
