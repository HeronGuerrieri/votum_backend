namespace VotumServer.Models;

public class VoteOption
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Votes { get; set; } = 0;
    public bool IsWinner { get; set; } = false;
    public Guid VotationId { get; set; }
    public Votation Votation { get; set; }
}