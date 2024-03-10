using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data.Project;
using ProjectManagement.Models;
using ProjectManagement.Unit;

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProjectController(IMapper mapper,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
           _unitOfWork = unitOfWork;
        }
        //Get all projects
        [HttpGet("GetProjects")]
        public async Task<ActionResult<IList<GetProjectDto>>> GetProjects()
        {
            //var projects = await _context.Projects.ToListAsync();
            var projects = await _unitOfWork.Projects.GetAllAsync();
            var result = _mapper.Map<List<GetProjectDto>>(projects);
            return Ok(result);
        }
        //Get project by id
        [HttpGet("ProjectDetails/{id}")]
        public async Task<ActionResult<ProjectDto>> GetProjectById(int id)
        {
            //var project = await _context.Projects.Where(b => !b.IsDeleted).Include(p=>p.TaskGroups).FirstOrDefaultAsync(p=>p.Id==id);    
            //var project = await _context.Projects.Include(p => p.TaskGroups)
            //    .FirstOrDefaultAsync(p => p.Id == id);
            var project = await _unitOfWork.Projects.GetAsync(id);

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
            await _unitOfWork.Projects.AddAsync(project);
            return CreatedAtAction("GetProjects", new { id = project.Id }, project);
        }

        // update project
        [HttpPut("UpdateProject/{id}")]
        public async Task<IActionResult> PutProject(int id, UpdateProjectDto updateProjectDto)
        {
            if (id != updateProjectDto.Id)
            {
                return BadRequest("Invalid Record Id");
            }

            //_context.Entry(country).State = EntityState.Modified;
            var project = await _unitOfWork.Projects.GetAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            _mapper.Map(updateProjectDto, project);

            try
            {
                await _unitOfWork.Projects.UpdateAsync(project);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ProjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(project);
        }

        private async Task<bool> ProjectExists(int id)
        {
            return await _unitOfWork.Projects.Exist(id);
        }
    }
}
