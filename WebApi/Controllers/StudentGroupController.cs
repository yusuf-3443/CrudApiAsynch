using Domain.Models;
using Domain.Responses;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/StudentGroups")]
[ApiController]
public class StudentGroupController(IStudentGroupService studentGroupService):ControllerBase
{
    private readonly IStudentGroupService _studentGroupService = studentGroupService;
    [HttpGet]
    public async Task<Response<List<StudentGroup>>> GetStudentGroupsAsync()
    {
        return await _studentGroupService.GetStudentGroupsAsync();
    }
    [HttpGet("{studentGroupId:int}")]
    public async Task<Response<StudentGroup>> GetStudentGroupByIdAsync(int studentGroupId)
    {
        return await _studentGroupService.GetStudentGroupByIdAsync(studentGroupId);
    }
    [HttpPost]
    public async Task<Response<string>> CreateStudentGroupAsync(StudentGroup studentGroup)
    {
        return await _studentGroupService.CreateStudentGroupAsync(studentGroup);
    }
    [HttpPut]
    public async Task<Response<string>> UpdateStudentGroupAsync(StudentGroup studentGroup)
    {
        return await _studentGroupService.UpdateStudentGroupAsync(studentGroup);
    }
    [HttpDelete("{studentGroupId:int}")]
    public async Task<Response<bool>> DeleteStudentGroupAsync(int studentGroupId)
    {
        return await _studentGroupService.DeleteStudentGroupAsync(studentGroupId);
    }
}