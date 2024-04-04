using Domain.Models;
using Domain.Responses;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/Groups")]
[ApiController]
public class GroupController(IGroupService groupService):ControllerBase
{
    private readonly IGroupService _groupService = groupService;
    [HttpGet]
    public async Task<Response<List<Group>>> GetGroupsAsync()
    {
        return await _groupService.GetGroupsAsync();
    }
    [HttpGet("{groupId:int}")]
    public async Task<Response<Group>> GetGroupByIdAsync(int groupId)
    {
        return await _groupService.GetGroupByIdAsync(groupId);
    }

    [HttpPost]
    public async Task<Response<string>> CreateGroupAsync(Group group)
    {
        return await _groupService.CreateGroupAsync(group);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateGroupAsync(Group group)
    {
        return await _groupService.UpdateGroupAsync(group);
    }

    [HttpDelete("{groupId:int}")]
    public async Task<Response<bool>> DeleteGroupAsync(int groupId)
    {
        return await _groupService.DeleteGroupAsync(groupId);
    }
}