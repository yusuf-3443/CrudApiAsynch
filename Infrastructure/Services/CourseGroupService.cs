using System.Net;
using Dapper;
using Domain.Models;
using Domain.Responses;
using Infrastructure.DataContext;

namespace Infrastructure.Services;

public class CourseGroupService : ICourseGroupService
{
    private readonly DapperContext _context;

    public CourseGroupService(DapperContext context)
    {
        _context = context;
    }

    public async Task<Response<List<CourseGroup>>> GetCourseGroupsAsync()
    {
        try
        {

        var sql = $"Select * from coursegroup1";
        var result = await _context.Connection().QueryAsync<CourseGroup>(sql);
        return new Response<List<CourseGroup>>(result.ToList());
        
        }
        catch (Exception e)
        {
            return new Response<List<CourseGroup>>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<CourseGroup>> GetCourseGroupByIdAsync(int id)
    {
        try
        {
            var sql = $"Select * from coursegroup1 where id = {@id}";
            var result = await _context.Connection().QueryFirstOrDefaultAsync<CourseGroup>(sql);
            if (result != null) return new Response<CourseGroup>(result);
            return new Response<CourseGroup>(HttpStatusCode.BadRequest, "CourseGroup not found");
        }
        catch (Exception e)
        {
            return new Response<CourseGroup>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> CreateCourseGroupAsync(CourseGroup courseGroup)
    {
        try
        {
            var sql = $"Insert into coursegroup1(courseid,groupid)" +
                      $"values ({courseGroup.CourseId},{courseGroup.GroupId})";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("CourseGroup successfully added");
            return new Response<string>(HttpStatusCode.BadRequest, "Failed to add coursegroup");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> UpdateCourseGroupAsync(CourseGroup courseGroup)
    {
        try
        {
            var sql = $"Update coursegroup1 set" +
                      $" courseid = {courseGroup.CourseId},groupid = {courseGroup.GroupId} where id = {@courseGroup.Id}";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<string>("successfully");
            return new Response<string>(HttpStatusCode.BadRequest, "failed");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteCourseGroupAsync(int id)
    {
        try
        {

        var sql = $"Delete from coursegroup1 where id = {@id}";
        var result = await _context.Connection().ExecuteAsync(sql);
        if (result > 0) return new Response<bool>(true);
        return new Response<bool>(HttpStatusCode.BadRequest, "Failed to delete");
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
        }
}