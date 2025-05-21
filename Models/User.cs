using System;
using System.Collections.Generic;
using VotumServer.Enums;

namespace VotumServer.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsEmailConfirmed { get; set; }

        public List<Votation> CreatedVotations { get; set; } = new();
        public List<Votation> ParticipatedVotations { get; set; } = new();

        public bool TwoFactorEnabled { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ProfilePictureUrl { get; set; }
    }
}