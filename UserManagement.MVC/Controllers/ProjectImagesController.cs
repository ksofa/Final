using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagement.MVC.Data;
using UserManagement.MVC.Models;

namespace UserManagement.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectImagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjectImagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProjectImages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectImage>>> GetProjectImage()
        {
            return await _context.ProjectImage.ToListAsync();
        }

        // GET: api/ProjectImages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectImage>> GetProjectImage(int id)
        {
            var projectImage = await _context.ProjectImage.FindAsync(id);

            if (projectImage == null)
            {
                return NotFound();
            }

            return projectImage;
        }


        // POST: api/ProjectImages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjectImage>> PostProjectImage(ProjectImage projectImage)
        {
            _context.ProjectImage.Add(projectImage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectImage", new { id = projectImage.Id }, projectImage);
        }

        // DELETE: api/ProjectImages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectImage(int id)
        {
            var projectImage = await _context.ProjectImage.FindAsync(id);
            if (projectImage == null)
            {
                return NotFound();
            }

            _context.ProjectImage.Remove(projectImage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectImageExists(int id)
        {
            return _context.ProjectImage.Any(e => e.Id == id);
        }
    }
}
