﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.MVC.Data;
using UserManagement.MVC.Models;

namespace UserManagement.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProposalController : ControllerBase
    {
        private ApplicationDbContext db;

        public ProposalController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        // GET: api/<ProposalController>
        [HttpGet]
        public IEnumerable<Proposal> Get()
        {
            return db.Proposals.ToList();
        }

        // GET api/<ProposalController>/5
        [HttpGet("{id}")]
        public Proposal Get(int id)
        {
            Proposal n = db.Proposals.Find(id);
            return n;
        }

        // POST api/<ProposalController>
        [HttpPost]
        public Proposal Post(Proposal n)
        {
            if (ModelState.IsValid)
            {
                db.Proposals.Add(n);
                db.SaveChanges();
            }
            return n;
        }
    }
}
