using BackEnd.Entitys;

namespace BackEnd.DBContex.Interfaces;

public interface IVoteRepository
{
    Task<IEnumerable<Votes>> GetAllVotesAsync();
    
    Task<Votes> GetVoteByIdAsync(int id);
    Task<Votes> AddVoteAsync(Votes poll);
    Task<Votes> UpdateVoteAsync(Votes poll);
}