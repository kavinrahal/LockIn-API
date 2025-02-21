using LockIn_API.DTOs;
using LockIn_API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LockIn_API.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly ITokenService _tokenService;

        public UserService(ApplicationDbContext context,
                           IPasswordHasher<User> passwordHasher,
                           ITokenService tokenService)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        public async Task<UserProfileDto> RegisterUserAsync(UserRegisterDto userRegisterDto)
        {
            // Check if the email is already registered.
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == userRegisterDto.Email);
            if (existingUser != null)
            {
                throw new Exception("A user with this email already exists.");
            }

            var user = new User
            {
                UserId = Guid.NewGuid(),
                FullName = userRegisterDto.FullName,
                Email = userRegisterDto.Email,
                CreatedAt = DateTime.UtcNow
            };

            // Hash the password.
            user.PasswordHash = _passwordHasher.HashPassword(user, userRegisterDto.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Map the entity to a profile DTO.
            var profile = new UserProfileDto
            {
                UserId = user.UserId,
                FullName = user.FullName,
                Email = user.Email,
                ProfilePicture = user.ProfilePicture,
                CreatedAt = user.CreatedAt
            };

            return profile;
        }

        public async Task<TokenResultDto> LoginUserAsync(UserLoginDto userLoginDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == userLoginDto.Email);
            if (user == null)
            {
                return null;
            }

            // Verify the password.
            var verificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, userLoginDto.Password);
            if (verificationResult == PasswordVerificationResult.Failed)
            {
                return null;
            }

            // Generate a JWT token (using your ITokenService).
            var token = _tokenService.GenerateToken(user);

            var tokenResult = new TokenResultDto
            {
                Token = token,
                Expiration = DateTime.UtcNow.AddHours(1)
            };

            return tokenResult;
        }

        public async Task<UserProfileDto> GetUserProfileAsync(Guid userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            var profile = new UserProfileDto
            {
                UserId = user.UserId,
                FullName = user.FullName,
                Email = user.Email,
                ProfilePicture = user.ProfilePicture,
                CreatedAt = user.CreatedAt
            };

            return profile;
        }

        public async Task<UserProfileDto> UpdateUserProfileAsync(Guid userId, UserUpdateDto userUpdateDto)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            user.FullName = userUpdateDto.FullName;
            user.ProfilePicture = userUpdateDto.ProfilePicture;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            var updatedProfile = new UserProfileDto
            {
                UserId = user.UserId,
                FullName = user.FullName,
                Email = user.Email,
                ProfilePicture = user.ProfilePicture,
                CreatedAt = user.CreatedAt
            };

            return updatedProfile;
        }

        public async Task InitiatePasswordResetAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                throw new Exception("Email not found.");
            }

            // Generate a reset token (e.g., a GUID or a secure token) and send it via email.
            // For demonstration purposes, we'll generate a GUID.
            var resetToken = Guid.NewGuid().ToString();

            // TODO: Save the reset token associated with the user (e.g., in a ResetTokens table)
            // TODO: Use an email service to send the token to the user.
            // For now, we simply simulate the process.
            Console.WriteLine($"Password reset token for {email}: {resetToken}");
        }

        public async Task ResetPasswordAsync(string resetToken, string newPassword)
        {
            // In a real implementation, you'd look up the reset token in a dedicated table,
            // verify its validity and expiration, then retrieve the associated user.
            // For this example, we'll throw a NotImplementedException to indicate that
            // further logic is required.
            throw new NotImplementedException("ResetPasswordAsync is not implemented. Implement token lookup and password reset logic.");
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
