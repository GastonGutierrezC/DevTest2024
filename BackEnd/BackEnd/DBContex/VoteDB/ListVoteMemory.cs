using BackEnd.DBContex.Interfaces;
using BackEnd.Entitys;

namespace BackEnd.DBContex.VoteDB;

public class ListVoteMemory : IVoteRepository
{
    private List<Votes> _votes = new();
    private IPollRepository _pollRepository;

    public ListVoteMemory(IPollRepository pollRepository)
    {
        _pollRepository = pollRepository;
    }
    
    public Task<IEnumerable<Votes>> GetAllVotesAsync()
    {
  
        
        var getAllPolls = Task.FromResult(_votes.AsEnumerable());
        return getAllPolls;
    }

    public Task<Votes> GetVoteByIdAsync(int id)
    {

        
        var getPoll = Task.FromResult(_votes.FirstOrDefault(m=> m.OptionId == id));
        return getPoll;
    }

    public async Task<Votes> AddVoteAsync(Votes votes)
    {
        
        var poll = (await _pollRepository.GetAllPollsAsync()).FirstOrDefault(p => p.Options.Any(o => o.OptionId == votes.OptionId));

        if (poll == null)
        {
            return null;
        }
        var option = poll.Options.FirstOrDefault(o => o.OptionId == votes.OptionId);
        if (option == null)
        {
            return null;
        }

        option.OptionVotes += 1;
        
        await _pollRepository.UpdatePollAsync(poll);
        
        _votes.Add(votes);
        return votes;
        

    }

    public Task<Votes> UpdateVoteAsync(Votes votes)
    {
        votes.OptionId = _votes.Count + 1;
        var updateVotes = _votes.FirstOrDefault(m=> m.OptionId == votes.OptionId);
        
        updateVotes.OptionVotes = updateVotes.OptionVotes + 1;
        
        _votes.Add(votes);
        return Task.FromResult(updateVotes);
    }
}