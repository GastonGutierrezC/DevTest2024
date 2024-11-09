using BackEnd.DBContex.Interfaces;
using BackEnd.DTOs;
using BackEnd.Entitys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers;


[ApiController]
[Route("[controller]")]
public class PollController : ControllerBase
{
    private IPollRepository _pollRepository;

    public PollController(IPollRepository pollRepository)
    {
        _pollRepository = pollRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPolls()
    {

        var polls = await _pollRepository.GetAllPollsAsync();
        return Ok(polls);

    }

    [HttpPost]
    public async Task<IActionResult> AddPoll([FromBody] PollDTO pollDto)
    {
        var poll = new Poll()
        {
            PollName = pollDto.PollName,
            Options = pollDto.Options,
        };
        
        var newPoll = await _pollRepository.AddPollAsync(poll);
        return Ok(newPoll);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdatePoll([FromBody] PollDTO pollDto, int id)
    {
        
        var getPoll = await _pollRepository.GetPollByIdAsync(id);
        getPoll.PollName = pollDto.PollName;
        getPoll.Options = pollDto.Options;
        
        var newPoll = await _pollRepository.UpdatePollAsync(getPoll);
        return Ok(newPoll);

    }
    
}