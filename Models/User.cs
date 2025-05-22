using System;
using System.Collections.Generic;
using VotumServer.Enums;

namespace VotumServer.Models
{
    public class User
    {
        public Guid Id { get; init; }
        public string Username { get; init; }
        public string Email { get; init; }
        public string PasswordHash { get; set; }
        public string FullName { get; init; }
        public Gender Gender { get; init; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsEmailConfirmed { get; init; }
        public bool TwoFactorEnabled { get; init; }
        public string? PhoneNumber { get; init; }
        public string? ProfilePictureUrl { get; init; }
    }
}