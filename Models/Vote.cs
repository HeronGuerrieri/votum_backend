namespace VotumServer.Models
{
    public class Vote
    {
        public Guid Id { get; set; }                  
        public Guid UserId { get; set; }              
        public Guid VotationId { get; set; }          
        public DateTime VoteDate { get; set; }        
        public Guid? VoteOptionId { get; set; }   
        public VoteOption VoteOption { get; set; }
        public bool IsValid { get; set; }             
        public bool IsAnonymous { get; set; }      
        
        public double Weight { get; set; } = 1.0;     
    }
}