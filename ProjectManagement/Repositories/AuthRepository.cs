using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ProjectManagement.Contracts;
using ProjectManagement.Data.User;
using ProjectManagement.Models;

namespace ProjectManagement.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AuthUser> _userManager;

        public AuthRepository(IMapper mapper,UserManager<AuthUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<IEnumerable<IdentityError>> Register(UserDto userDto)
        {
            var user = _mapper.Map<AuthUser>(userDto);
            user.UserName = userDto.Email;

            var result = await _userManager.CreateAsync(user,userDto.Password); 

            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }
            return result.Errors;
        }
    }
}
