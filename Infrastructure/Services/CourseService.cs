using System.Net;
using Dapper;
using Domain.Models;
using Domain.Responses;
using Infrastructure.DataContext;

namespace Infrastructure.Services;

public class CourseService : ICourseService
{
    private readonly DapperContext _context;

    public CourseService(DapperContext context)
    {
        _context = context;
    }

    public async Task<Response<List<Course>>> GetCoursesAsync()
    {
        try
        {

        var sql = $"Select * from course";
        var result = await _context.Connection().QueryAsync<Course>(sql);
        return new Response<List<Course>>(result.ToList());
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<List<Course>>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<Course>> GetCourseByIdAsync(int id)
    {
        try
        {

        var sql = $"Select * from course where id = {@id}";
        var result = await _context.Connection().QueryFirstOrDefaultAsync<Course>(sql);
        if (result != null) return new Response<Course>(result);
        return new Response<Course>(HttpStatusCode.BadRequest, "Not found");
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<Course>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<string>> CreateCourseAsync(Course course)
    {
        try
        {

        var sql = $"Insert into course(coursename,coursedescription,fee,duration,startdate,enddate,studentlimit)" +
                  $"values ('{course.CourseName}','{course.CourseDescription}',{course.Fee},{course.Duration},'{course.StartDate}','{course.EndDate}',{course.StudentLimit})";
        var result = await _context.Connection().ExecuteAsync(sql);
        if (result > 0) return new Response<string>("Successfully course added");
        return new Response<string>(HttpStatusCode.BadRequest, "Failed to add course");
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<string>> UpdateCourseAsync(Course course)
    {
        try
        {

        var sql = $"Update course " +
                  $"set coursename = '{course.CourseName}', coursedescription = '{course.CourseDescription}', " +
                  $"fee = {course.Fee},duration  = {course.Duration},startdate = '{course.StartDate}'," +
                  $"enddate = '{course.EndDate}',studentlimit = {course.StudentLimit} where id = {@course.Id}";
        var result = await _context.Connection().ExecuteAsync(sql);
        if (result > 0) return new Response<string>("Course successfully updated");
        return new Response<string>(HttpStatusCode.BadRequest, "Failed to update course");
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<bool>> DeleteCourseAsync(int id)
    {
        try
        {
            var sql = $"Delete from course where id = {@id}";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<bool>(true);
            return new Response<bool>(HttpStatusCode.BadRequest, "Failed to delete course");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}