using System.Security.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VotumServer.DTOs;
using VotumServer.Exceptions;
using VotumServer.Models;
using VotumServer.Services;

namespace VotumServer.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class AuthController(AuthService authService, JwtService jwtService) : ControllerBase
    {
        private readonly JwtService _jwtService = jwtService;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                FullName = dto.FullName,
                Gender = dto.Gender,
                PhoneNumber = dto.PhoneNumber,
                ProfilePictureUrl = dto.ProfilePictureUrl
            };

            var createdUser = await authService.RegisterUserAsync(user, dto.Password);

            var response = new AuthResponseDto
            {
                Id = createdUser.Id,
                Username = createdUser.Username,
                Email = createdUser.Email,
                FullName = createdUser.FullName,
                ProfilePictureUrl = createdUser.ProfilePictureUrl,
                TwoFactorEnabled = createdUser.TwoFactorEnabled,
                Token = _jwtService.GenerateToken(createdUser)
            };

            return Created($"/api/auth/{createdUser.Id}", response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            try
            {
                var user = await authService.LoginAsync(dto.Username, dto.Password);

                var response = new AuthResponseDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Email = user.Email,
                    FullName = user.FullName,
                    ProfilePictureUrl = user.ProfilePictureUrl,
                    TwoFactorEnabled = user.TwoFactorEnabled,
                    Token = _jwtService.GenerateToken(user)
                };

                return Ok(response);
            }
            catch (UserNotFoundException)
            {
                return Unauthorized(new { message = "User does not exists" });
            }
            catch (InvalidCredentialException) 
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal error, try again later.", error = ex.Message });
            }
        }
    }
}