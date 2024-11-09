using BackEnd.DBContex.Interfaces;
using BackEnd.Entitys;

namespace BackEnd.DBContex.PollDB;

public class ListMemory : IPollRepository
{

    private List<Poll> _polls = new();
    
    public Task<IEnumerable<Poll>> GetAllPollsAsync()
    {
        
        var getAllPolls = Task.FromResult(_polls.AsEnumerable());
        return getAllPolls;
        
    }

    public Task<Poll> GetPollByIdAsync(int id)
    {
        
        var getPoll = Task.FromResult(_polls.FirstOrDefault(m=> m.PollId == id));
        return getPoll;
    }

    public Task<Poll> AddPollAsync(Poll poll)
    {
        poll.PollId = _polls.Count + 1;
        _polls.Add(poll);
        var addPoll = Task.FromResult(poll);
        return addPoll;
    }

    public Task<Poll> UpdatePollAsync(Poll poll)
    {

        var updatePool = _polls.FirstOrDefault(m=> m.PollId == poll.PollId);
        updatePool.PollName = poll.PollName;
        updatePool.Options = poll.Options;
        
        return Task.FromResult(updatePool);

    }
}