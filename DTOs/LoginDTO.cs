using System.ComponentModel.DataAnnotations;

namespace VotumServer.DTOs
{
    public record LoginDto(
        [Required(ErrorMessage = "The username is required.")]
        string Username,

        [Required(ErrorMessage = "The password is required.")]
        string Password
    );
}