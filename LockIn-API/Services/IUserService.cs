using LockIn_API.DTOs;

namespace LockIn_API.Services
{
    public interface IUserService
    {
        Task<UserProfileDto> RegisterUserAsync(UserRegisterDto userRegisterDto);
        Task<TokenResultDto> LoginUserAsync(UserLoginDto userLoginDto);
        Task<UserProfileDto> GetUserProfileAsync(Guid userId);
        Task<UserProfileDto> UpdateUserProfileAsync(Guid userId, UserUpdateDto userUpdateDto);
        Task InitiatePasswordResetAsync(string email);
        Task ResetPasswordAsync(string resetToken, string newPassword);
        Task<bool> DeleteUserAsync(Guid userId);
    }
}
