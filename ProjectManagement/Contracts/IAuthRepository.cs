using Microsoft.AspNetCore.Identity;
using ProjectManagement.Data.User;

namespace ProjectManagement.Contracts
{
    public interface IAuthRepository
    {
        Task<IEnumerable<IdentityError>> Register(UserDto user);
        Task<AuthResponseDto> Login(LoginDto loginDto);
    }
}
