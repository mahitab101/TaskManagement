using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Construction;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Models;

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ProjectController(ApplicationDBContext context)
        {
            _context = context;
        }
        //Get 
        [HttpGet("GetProjects")]
        public async Task<ActionResult<IList<Project>>> GetProject()
        {
            var projects =  await _context.Projects.ToListAsync();
            return Ok(projects);
        }

    }
}
