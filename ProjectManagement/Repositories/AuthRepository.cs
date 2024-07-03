using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjectManagement.Contracts;
using ProjectManagement.Data.User;
using ProjectManagement.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectManagement.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AuthUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDBContext _dBContext;

        public AuthRepository(IMapper mapper,UserManager<AuthUser> userManager,IConfiguration configuration,ApplicationDBContext dBContext)
        {
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            _dBContext = dBContext;
        }

        public async Task<AuthResponseDto> Login(LoginDto loginDto)
        {
            
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            bool isValidUser = await _userManager.CheckPasswordAsync(user, loginDto.Password);

           if (user==null || isValidUser==false)
            {
            return null;    
            }
            var token=await GenerateToken(user);
            return new AuthResponseDto
            {
                Token = token,
                UserId = user.Id
            };

        }

        public async Task<IEnumerable<IdentityError>> Register(UserDto userDto)
        {
            var user = _mapper.Map<AuthUser>(userDto);
            bool emailWithSameNameExist = await _dBContext.Users.AnyAsync(e => e.Email == userDto.Email);

            if (emailWithSameNameExist)
            {
                throw new Exception("This email already exists");
            }

            user.UserName = userDto.Email;

            var result = await _userManager.CreateAsync(user,userDto.Password); 

            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }
            return result.Errors;
        }
        private async Task<string> GenerateToken(AuthUser authUser)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSetings:Key"]));

            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(authUser);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();

            var userClaims = await _userManager.GetClaimsAsync(authUser);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,authUser.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,authUser.Email),
                new Claim("uid",authUser.Id)
            }.Union(userClaims).Union(roleClaims);
            // token 
            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSetings:Issuer"],
                audience: _configuration["JwtSetings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtSetings:DurationInMinutes"])),
                signingCredentials:credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
