using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Models;

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskGroupController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public TaskGroupController(ApplicationDBContext context)
        {
            _context = context;
        }
    }
}
