using System.ComponentModel.DataAnnotations;

namespace LockIn_API.DTOs
{
    public class UserRegisterDto
    {
        [Required(ErrorMessage = "Full Name is required.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Email must be valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone]
        public string PhoneNumber {  get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }
    }

    /// <summary>
    /// DTO for user login.
    /// </summary>
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Email must be valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }

    /// <summary>
    /// DTO for updating user profile information.
    /// </summary>
    public class UserUpdateDto
    {
        [Required(ErrorMessage = "Full Name is required.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        public string PhoneNumber { get; set; }

        public string ProfilePicture { get; set; }
    }

    /// <summary>
    /// DTO for initiating a password reset.
    /// </summary>
    public class ForgotPasswordDto
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Email must be valid.")]
        public string Email { get; set; }
    }

    /// <summary>
    /// DTO for resetting the password.
    /// </summary>
    public class ResetPasswordDto
    {
        [Required(ErrorMessage = "Reset token is required.")]
        public string ResetToken { get; set; }

        [Required(ErrorMessage = "New password is required.")]
        [MinLength(6, ErrorMessage = "New password must be at least 6 characters long.")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Please confirm your new password.")]
        [Compare("NewPassword", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }

    /// <summary>
    /// DTO for returning user profile details.
    /// </summary>
    public class UserProfileDto
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string ProfilePicture { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    /// <summary>
    /// DTO for returning an authentication token.
    /// </summary>
    public class TokenResultDto
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}

