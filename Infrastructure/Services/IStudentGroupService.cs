using Domain.Models;
using Domain.Responses;

namespace Infrastructure.Services;

public interface IStudentGroupService
{
    Task<Response<List<StudentGroup>>> GetStudentGroupsAsync();
    Task<Response<StudentGroup>> GetStudentGroupByIdAsync(int id);
    Task<Response<string>> CreateStudentGroupAsync(StudentGroup studentGroup);
    Task<Response<string>> UpdateStudentGroupAsync(StudentGroup studentGroup);
    Task<Response<bool>> DeleteStudentGroupAsync(int id);
}