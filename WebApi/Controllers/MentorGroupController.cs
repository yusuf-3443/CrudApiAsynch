using Domain.Models;
using Domain.Responses;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/MentorGroups")]
[ApiController]
public class MentorGroupController(IMentorGroupService mentorGroupService):ControllerBase
{
    private readonly IMentorGroupService _mentorGroupService = mentorGroupService;
    [HttpGet]
    public async Task<Response<List<MentorGroup>>> GetMentorGroupsAsync()
    {
        return await _mentorGroupService.GetMentorGroupsAsync();
    }
    [HttpGet("{mentorGroupId:int}")]
    public async Task<Response<MentorGroup>> GetMentorGroupByIdAsync(int mentorGroupId)
    {
        return await _mentorGroupService.GetMentorGroupByIdAsync(mentorGroupId);
    }
    [HttpPost]
    public async Task<Response<string>> CreateMentorGroupAsync(MentorGroup mentorGroup)
    {
        return await _mentorGroupService.CreateMentorGroupAsync(mentorGroup);
    }
    [HttpPut]
    public async Task<Response<string>> UpdateMentorGroupAsync(MentorGroup mentorGroup)
    {
        return await _mentorGroupService.UpdateMentorGroupAsync(mentorGroup);
    }
    [HttpDelete("{mentorGroupId:int}")]
    public async Task<Response<bool>> DeleteMentorGroupAsync(int mentorGroupId)
    {
        return await _mentorGroupService.DeleteMentorGroupAsync(mentorGroupId);
    }
}