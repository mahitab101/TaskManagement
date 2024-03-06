using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data.TaskGroup;
using ProjectManagement.Models;

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskGroupController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public TaskGroupController(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // get all task group for project
        [HttpGet("GetTaskGroup")]
        public async Task<ActionResult<IList<TaskGroupDto>>> GetTaskGroup()
        {
            var taskGroup = await _context.TaskGroups.ToListAsync();
            var result = _mapper.Map<List<TaskGroupDto>>(taskGroup);
            return Ok(result);
        }

        //get task group by id
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskGroup>> GetTaskGroupById(int id)
        {
            var taskGroup = await _context.TaskGroups.FindAsync(id);
            if (taskGroup == null)
            {
                return NotFound();
            }
            return Ok(taskGroup);
        }

        // add project task group
        [HttpPost("AddTaskGroup")]
        public async Task<ActionResult<TaskGroup>> AddGroup(CreateTaskGroupDto taskGroupDto)
        {
            var taskGroup = _mapper.Map<TaskGroup>(taskGroupDto);
            await _context.TaskGroups.AddAsync(taskGroup);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTaskGroup", new { id = taskGroup.Id }, taskGroup);
        }
    }
}
