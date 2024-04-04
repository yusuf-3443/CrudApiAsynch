using Domain.Models;
using Domain.Responses;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/CourseGroups")]
[ApiController]
public class CourseGroupController(ICourseGroupService courseGroupService):ControllerBase
{
    private readonly ICourseGroupService _courseGroupService = courseGroupService;
    [HttpGet]
    public async Task<Response<List<CourseGroup>>> GetCourseGroupsAsync()
    {
        return await _courseGroupService.GetCourseGroupsAsync();
    }
    [HttpGet("{courseGroupId:int}")]
    public async Task<Response<CourseGroup>> GetCourseGroupByIdAsync(int courseGroupId)
    {
        return await _courseGroupService.GetCourseGroupByIdAsync(courseGroupId);
    }
    [HttpPost]
    public async Task<Response<string>> CreateCourseGroupAsync(CourseGroup courseGroup)
    {
        return await _courseGroupService.CreateCourseGroupAsync(courseGroup);
    }
    [HttpPut]
    public async Task<Response<string>> UpdateCourseGroupAsync(CourseGroup courseGroup)
    {
        return await _courseGroupService.UpdateCourseGroupAsync(courseGroup);
    }
    [HttpDelete("{courseGroupId:int}")]
    public async Task<Response<bool>> DeleteCourseGroupAsync(int courseGroupId)
    {
        return await _courseGroupService.DeleteCourseGroupAsync(courseGroupId);
    }
}