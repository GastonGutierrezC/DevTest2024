using BackEnd.Entitys;

namespace BackEnd.DBContex.Interfaces;

public interface IPollRepository
{
    Task<IEnumerable<Poll>> GetAllPollsAsync();
    
    Task<Poll> GetPollByIdAsync(int id);
    Task<Poll> AddPollAsync(Poll poll);
    Task<Poll> UpdatePollAsync(Poll poll);
}