using Domain.Models;
using Domain.Responses;

namespace Infrastructure.Services;

public interface IStudentService
{
    Task<Response<List<Student>>> GetStudentsAsync();
    Task<Response<Student>> GetStudentByIdAsync(int id);
    Task<Response<string>> CreateStudentAsync(Student student);
    Task<Response<string>> UpdateStudentAsync(Student student);
    Task<Response<bool>> DeleteStudentAsync(int id);
}