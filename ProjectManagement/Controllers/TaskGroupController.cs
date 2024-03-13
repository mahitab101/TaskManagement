using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Data.TaskGroup;
using ProjectManagement.Models;
using ProjectManagement.Unit;

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskGroupController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TaskGroupController(IMapper mapper,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
           _unitOfWork = unitOfWork;
        }
        // get all task group for project
        [HttpGet("GetTaskGroup")]
        public async Task<ActionResult<IList<TaskGroupDto>>> GetTaskGroup()
        {
            var taskGroup = await _unitOfWork.TaskGroups.GetAllAsync();
            var result = _mapper.Map<List<TaskGroupDto>>(taskGroup);
            return Ok(result);
        }

        //get task group by id
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskGroup>> GetTaskGroupById(int id)
        {
            var taskGroup = await _unitOfWork.TaskGroups.GetAsync(id);
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
            await _unitOfWork.TaskGroups.AddAsync(taskGroup);
            return CreatedAtAction("GetTaskGroup", new { id = taskGroup.Id }, taskGroup);
        }
    }
}
