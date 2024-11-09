using BackEnd.DBContex.Interfaces;
using BackEnd.DTOs;
using BackEnd.Entitys;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;

[ApiController]
[Route("[controller]")]
public class VotesControllers : ControllerBase
{
    
    private IVoteRepository _repository;

    public VotesControllers(IVoteRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var votes = await _repository.GetAllVotesAsync();
        return Ok(votes);
    }

    [HttpPost]
    public async Task<IActionResult> addVote([FromBody] VotesDTO votesDto)
    {
        
        
        var vote = new Votes()
        {
            VoterEmail = votesDto.VoterEmail,
            VotesId = votesDto.OptionVotes,
            OptionVotes = 1
            
           
        };
        
        var newVote = await _repository.AddVoteAsync(vote);
        
        return Ok(newVote);
    }
    
}