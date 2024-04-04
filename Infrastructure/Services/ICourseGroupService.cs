using Domain.Models;
using Domain.Responses;

namespace Infrastructure.Services;

public interface ICourseGroupService
{
    Task<Response<List<CourseGroup>>> GetCourseGroupsAsync();
    Task<Response<CourseGroup>> GetCourseGroupByIdAsync(int id);
    Task<Response<string>> CreateCourseGroupAsync(CourseGroup courseGroup);
    Task<Response<string>> UpdateCourseGroupAsync(CourseGroup courseGroup);
    Task<Response<bool>> DeleteCourseGroupAsync(int id);
}