using VotumServer.Enums;

namespace VotumServer.Models;

public class Votation
{
    public Guid Id { get; set; }
    public Guid CreatorId { get; set; }
    public User Creator { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Code { get; set; }
    public VotationStatus Status { get; set; }
    public VotationType Type { get; set; }
    public bool IsAnonymous { get; set; }
    public bool ShowPartialResults { get; set; }
    public bool ShowResultsToParticipants { get; set; }
    public DateTime? VotingStartDate { get; set; }
    public List<Guid> AllowedVoters { get; set; } = new List<Guid>();
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public Guid? LastModifiedBy { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public VotationVisibility Visibility { get; set; }
    public List<Tag> Tags { get; set; } = new List<Tag>();
    public List<VoteOption> VoteOptions { get; set; } = new List<VoteOption>();
    public List<Vote> Votes { get; set; } = new List<Vote>();
}