using BackEnd.Entitys;

namespace BackEnd.DTOs;

public class PollDTO
{
    public string PollName { get; set; }
    
    public List<Votes> Options { get; set; } = new List<Votes>();
}