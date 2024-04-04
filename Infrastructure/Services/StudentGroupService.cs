using System.Net;
using Dapper;
using Domain.Models;
using Domain.Responses;
using Infrastructure.DataContext;

namespace Infrastructure.Services;

public class StudentGroupService : IStudentGroupService
{
    private readonly DapperContext _context;

    public StudentGroupService(DapperContext context)
    {
        _context = context;
    }

    public async Task<Response<List<StudentGroup>>> GetStudentGroupsAsync()
    {
        try
        {

        var sql = $"Select * from studentgroup";
        var result = await _context.Connection().QueryAsync<StudentGroup>(sql);
        return new Response<List<StudentGroup>>(result.ToList());
        
        }
        catch (Exception e)
        {
            return new Response<List<StudentGroup>>(HttpStatusCode.InternalServerError,e.Message);
        }
        }

    public async Task<Response<StudentGroup>> GetStudentGroupByIdAsync(int id)
    {
        try
        {

        var sql = $"Select * from studentgroup where id = {@id}";
        var result = await _context.Connection().QueryFirstOrDefaultAsync<StudentGroup>(sql);
        if (result != null) return new Response<StudentGroup>(result);
        return new Response<StudentGroup>(HttpStatusCode.BadRequest, "Not found");
        
        }
        catch (Exception e)
        {
            return new Response<StudentGroup>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<string>> CreateStudentGroupAsync(StudentGroup studentGroup)
    {
        try
        {

        var sql = $"Insert into studentgroup(studentid,groupid)" +
                  $"values ({studentGroup.StudentId},{studentGroup.GroupId})";
        var result = await _context.Connection().ExecuteAsync(sql);
        if (result > 0) return new Response<string>("Successfully");
        return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<string>> UpdateStudentGroupAsync(StudentGroup studentGroup)
    {
        try
        {

        var sql = $"Update studentgroup " +
                  $"set studentid = {studentGroup.StudentId},groupid = {studentGroup.GroupId} where id = {@studentGroup.Id}";
        var result = await _context.Connection().ExecuteAsync(sql);
        if (result > 0) return new Response<string>("Successfully");
        return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<bool>> DeleteStudentGroupAsync(int id)
    {
        try
        {
            var sql = $"Delete from studentgroup where id = {@id}";
            var result = await _context.Connection().ExecuteAsync(sql);
            if (result > 0) return new Response<bool>(true);
            return new Response<bool>(HttpStatusCode.BadRequest, "Failed");
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}