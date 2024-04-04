using Domain.Models;
using Domain.Responses;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/Courses")]
[ApiController]
public class CourseController(ICourseService courseService):ControllerBase
{
    private readonly ICourseService _courseService = courseService;

    [HttpGet]
    public async Task<Response<List<Course>>> GetCoursesAsync()
    {
        return await _courseService.GetCoursesAsync();
    }
     
    [HttpGet("{courseId:int}")]
    public async Task<Response<Course>> GetCourseByIdAsync(int courseId)
    {
        return await _courseService.GetCourseByIdAsync(courseId);
    }

    [HttpPost]
    public async Task<Response<string>> CreateCourseAsync(Course course)
    {
        return await _courseService.CreateCourseAsync(course);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateCourseAsync(Course course)
    {
        return await _courseService.UpdateCourseAsync(course);
    }

    [HttpDelete("{courseId:int}")]
    public async Task<Response<bool>> DeleteCourseAsync(int courseId)
    {
        return await _courseService.DeleteCourseAsync(courseId);
    }
    
}