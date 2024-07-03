using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Contracts;
using ProjectManagement.Data.Project;
using ProjectManagement.Models;
using ProjectManagement.Unit;
using System.Security.Claims;

namespace ProjectManagement.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProjectRepository _projectRepository;

        public ProjectController(IMapper mapper,IUnitOfWork unitOfWork,IProjectRepository projectRepository)
        {
            _mapper = mapper;
           _unitOfWork = unitOfWork;
            _projectRepository = projectRepository;
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
            var project = await _projectRepository.GetDetails(id);

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
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var project = _mapper.Map<Project>(createProject);
            project.CreateUser = userId; 
            project.UpdateUser = userId;
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
