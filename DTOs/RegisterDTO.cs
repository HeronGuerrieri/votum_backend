using System.ComponentModel.DataAnnotations;
using VotumServer.Enums;

namespace VotumServer.DTOs
{
    public record RegisterDto(
        [Required(ErrorMessage = "The username is required.")]
        [MinLength(4, ErrorMessage = "The username must be at least 4 characters long.")]
        [MaxLength(20, ErrorMessage = "The username must be at most 20 characters long.")]
        string Username,

        [Required(ErrorMessage = "The email is required.")]
        [EmailAddress(ErrorMessage = "The email format is invalid.")]
        string Email,

        [Required(ErrorMessage = "The password is required.")]
        [MinLength(6, ErrorMessage = "The password must be at least 6 characters long.")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,}$", ErrorMessage = "The password must contain at least one uppercase letter, one lowercase letter, and one number.")]
        string Password,

        [Required(ErrorMessage = "The full name is required.")]
        string FullName,

        [Required(ErrorMessage = "The gender is required.")]
        Gender Gender,

        string? PhoneNumber,

        string? ProfilePictureUrl
    );
}