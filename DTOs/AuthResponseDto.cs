namespace VotumServer.DTOs;

public class AuthResponseDto
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public bool TwoFactorEnabled { get; set; }
    public string Token { get; set; } 
}