using BackEnd.DBContex.Interfaces;
using BackEnd.Entitys;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.DBContex.VoteDB;

public class MySQLMemoryVote : IVoteRepository
{
    
    private MyDataBaseContext _context;

    public MySQLMemoryVote(MyDataBaseContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Votes>> GetAllVotesAsync()
    {
        var getAllVotes= await _context.votes.ToListAsync();
        return getAllVotes;
    }

    public async Task<Votes> GetVoteByIdAsync(int id)
    {
        var getVotesById = await _context.votes.FindAsync(id);
        return getVotesById;
    }

    public async Task<Votes> AddVoteAsync(Votes poll)
    {
        _context.votes.Update(poll);
        await _context.SaveChangesAsync();
        return poll;
    }

    public async Task<Votes> UpdateVoteAsync(Votes poll)
    {
        _context.votes.Remove(poll);
        await _context.SaveChangesAsync();
        return poll;
    }
}