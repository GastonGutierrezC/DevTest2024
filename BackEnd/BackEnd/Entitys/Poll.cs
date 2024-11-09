namespace BackEnd.Entitys;

public class Poll
{
    public int PollId { get; set; }
    public string PollName { get; set; }
    
    public List<Votes> Options { get; set; } = new List<Votes>();
}