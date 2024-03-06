using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data.Project;
using ProjectManagement.Models;

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public ProjectController(ApplicationDBContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //Get all projects
        [HttpGet("GetProject")]
        public async Task<ActionResult<IList<GetProjectDto>>> GetProject()
        {
            var projects =  await _context.Projects.ToListAsync();
            var result = _mapper.Map<List<GetProjectDto>>(projects);
            return Ok(result);
        }
        //Get project by id
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDto>> GetProjectById(int id)
        {
            var project = await _context.Projects.Include(q=>q.TaskGroups).FirstOrDefaultAsync(q=>q.Id==id);
            if (project == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<ProjectDto>(project);
            return Ok(result);
        }
        //add new project 
        [HttpPost("AddProject")]
        public async Task<ActionResult<Project>> PostProject(CreateProjectDto createProject)
        {
          
            var project = _mapper.Map<Project>(createProject);
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetProject", new { id = project.Id }, project);
        }

    }
}
