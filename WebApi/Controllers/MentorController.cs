using Domain.Models;
using Domain.Responses;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/Mentors")]
[ApiController]
public class MentorController(IMentorService mentorService):ControllerBase
{
    private readonly IMentorService _mentorService = mentorService;

    [HttpGet]
    public async Task<Response<List<Mentor>>> GetMentorsAsync()
    {
        return await _mentorService.GetMentorsAsync();
    }
     
    [HttpGet("{mentorId:int}")]
    public async Task<Response<Mentor>> GetMentorByIdAsync(int mentorId)
    {
        return await _mentorService.GetMentorByIdAsync(mentorId);
    }

    [HttpPost]
    public async Task<Response<string>> CreateMentorAsync(Mentor mentor)
    {
        return await _mentorService.CreateMentorAsync(mentor);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateMentorAsync(Mentor mentor)
    {
        return await _mentorService.UpdateMentorAsync(mentor);
    }

    [HttpDelete("{mentorId:int}")]
    public async Task<Response<bool>> DeleteMentorAsync(int mentorId)
    {
        return await _mentorService.DeleteMentorAsync(mentorId);
    }
}