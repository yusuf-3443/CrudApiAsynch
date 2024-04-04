using Domain.Models;
using Domain.Responses;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("/api/Students")]
[ApiController]
public class StudentController(IStudentService studentService):ControllerBase
{
    private readonly IStudentService _studentService = studentService;
    [HttpGet]
    public async Task<Response<List<Student>>> GetStudentsAsync()
    {
        return await _studentService.GetStudentsAsync();
    }
     
    [HttpGet("{studentId:int}")]
    public async Task<Response<Student>> GetStudentByIdAsync(int studentId)
    {
        return await _studentService.GetStudentByIdAsync(studentId);
    }

    [HttpPost]
    public async Task<Response<string>> CreateStudentAsync(Student student)
    {
        return await _studentService.CreateStudentAsync(student);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateStudentAsync(Student student)
    {
        return await _studentService.UpdateStudentAsync(student);
    }

    [HttpDelete("{studentId:int}")]
    public async Task<Response<bool>> DeleteStudentAsync(int studentId)
    {
        return await _studentService.DeleteStudentAsync(studentId);
    }
}