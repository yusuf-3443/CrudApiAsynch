using Domain.Models;
using Domain.Responses;

namespace Infrastructure.Services;

public interface ICourseService
{
    Task<Response<List<Course>>> GetCoursesAsync();
    Task<Response<Course>> GetCourseByIdAsync(int id);
    Task<Response<string>> CreateCourseAsync(Course course);
    Task<Response<string>> UpdateCourseAsync(Course course);
    Task<Response<bool>> DeleteCourseAsync(int id);
}