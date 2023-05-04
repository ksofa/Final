//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using UserManagement.MVC.Data;
//using UserManagement.MVC.Models;
//using UserManagement.MVC.RepModels;

//namespace UserManagement.MVC.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ClientsController : ControllerBase
//    {
//        private readonly ApplicationDbContext _context;

//        public ClientsController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/<ClientsController>
//        [HttpGet]
//        [AllowAnonymous]
//        public IEnumerable<Client> Get()
//        {
//            return _context.Client.ToList();
//        }

//        // GET api/<ClientsController>/5
//        [HttpGet("{id}")]
//        public Client Get(int id)
//        {
//            Client client = _context.Client.Find(id);
//            // throw new Exception("не найден пользователь");
//            return client;
//        }

//        // POST api/<ClientsController>
//        [HttpPost]
//        public Client Post(ClientRepModel v)
//        {
//            var client = new Client
//            {
//               Email=v.Email,
//               FirstName=v.FirstName,
//               LastName=v.LastName,
//               PhoneNumber=v.PhoneNumber
//            };

//            if (client.Id != 0)
//            {
//                var bdproj = _context.Client.Find(client.Id);

//                bdproj.Email = client.Email;
//                bdproj.FirstName = client.FirstName;
//            }

//            if (ModelState.IsValid)
//            {
//                _context.Client.Add(client);
//                _context.SaveChanges();
//            }

//            return client;
//        }

//        // DELETE: api/Clients/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<Client>> DeleteClient(int id)
//        {
//            var client = await _context.Client.FindAsync(id);
//            if (client == null)
//            {
//                return NotFound();
//            }

//            _context.Client.Remove(client);
//            await _context.SaveChangesAsync();

//            return client;
//        }

      
//    }
//}
