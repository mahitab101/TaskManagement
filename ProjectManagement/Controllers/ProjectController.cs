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
            var projects =  await _context.Projects.Where(b => !b.IsDeleted)
                                    .ToListAsync();
            var result = _mapper.Map<List<GetProjectDto>>(projects);
            return Ok(result);
        }
        //Get project by id
        [HttpGet("ProjectDetails/{id}")]
        public async Task<ActionResult<ProjectDto>> GetProjectById(int id)
        {
            var project = await _context.Projects.Where(b => !b.IsDeleted).Include(p=>p.TaskGroups).FirstOrDefaultAsync(p=>p.Id==id);
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
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetProject", new { id = project.Id }, project);
        }

        // update project
        [HttpPut("UpdateProject/{id}")]
        public async Task<ActionResult<Project>> UpdateProject(int id,UpdateProjectDto updateProjectDto)
        {
            if (id != updateProjectDto.Id)
            {
                return BadRequest("Invalid Record id");
            }
           // _context.Entry(project).State = EntityState.Modified;
           var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            _mapper.Map(updateProjectDto, project);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}
