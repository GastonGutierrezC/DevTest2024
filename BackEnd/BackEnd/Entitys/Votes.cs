namespace BackEnd.Entitys;

public class Votes
{
    
    public int VotesId { get; set; }
    public string OptionName { get; set; }
    public int OptionVotes { get; set; }
    public string VoterEmail { get; set; }
}