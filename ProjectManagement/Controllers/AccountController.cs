using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Contracts;
using ProjectManagement.Data.User;
using ProjectManagement.Models;

namespace ProjectManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly ApplicationDBContext _dBContext;

        public AccountController(IAuthRepository authRepository,ApplicationDBContext dBContext)
        {
            _authRepository = authRepository;
            _dBContext = dBContext;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] UserDto userDto)
        {
            var errors =await _authRepository.Register(userDto);
            if(errors.Any())
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return Ok(userDto);
        }


        [HttpPost]
        [Route("Verify")]
        public async Task<ActionResult> Verify(string email)
        {
            var user =await _dBContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return BadRequest("Invalid email");
            }
            user.EmailConfirmed = true;
            await _dBContext.SaveChangesAsync();
            return Ok("user verfied");
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] LoginDto loginDto)
        {
            var authResponse = await _authRepository.Login(loginDto);
            if (authResponse==null)
            {
                return Unauthorized();
            }
            return Ok(authResponse);
        }

    }
}
