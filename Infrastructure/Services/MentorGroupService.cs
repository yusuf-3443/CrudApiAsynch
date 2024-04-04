using System.Net;
using Dapper;
using Domain.Models;
using Domain.Responses;
using Infrastructure.DataContext;

namespace Infrastructure.Services;

public class MentorGroupService : IMentorGroupService
{
    private readonly DapperContext _context;

    public MentorGroupService(DapperContext context)
    {
        _context = context;
    }

    public async Task<Response<List<MentorGroup>>> GetMentorGroupsAsync()
    {
        try
        {

        var sql = $"Select * from mentorgroup";
        var result = await _context.Connection().QueryAsync<MentorGroup>(sql);
        return new Response<List<MentorGroup>>(result.ToList());
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<List<MentorGroup>>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<MentorGroup>> GetMentorGroupByIdAsync(int id)
    {
        try
        {

        var sql = $"Select * from mentorgroup where id = {@id}";
        var result = await _context.Connection().QueryFirstOrDefaultAsync<MentorGroup>(sql);
        if (result != null) return new Response<MentorGroup>(result);
        return new Response<MentorGroup>(HttpStatusCode.BadRequest, "Not found");
        
        }
        catch (Exception e)
        {
            return new Response<MentorGroup>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<string>> CreateMentorGroupAsync(MentorGroup mentorGroup)
    {
        try
        {

        var sql = $"Insert into mentorgroup(mentorid,groupid)" +
                  $"values ({mentorGroup.MentorId},{mentorGroup.GroupId})";
        var result = await _context.Connection().ExecuteAsync(sql);
        if (result > 0) return new Response<string>("Successfully");
        return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<string>> UpdateMentorGroupAsync(MentorGroup mentorGroup)
    {
        try
        {

        var sql = $"Update mentorgroup " +
                  $"set mentorid = {mentorGroup.MentorId},groupid = {mentorGroup.GroupId} where id = {@mentorGroup.Id}";
        var result = await _context.Connection().ExecuteAsync(sql);
        if (result > 0) return new Response<string>("Successfully");
        return new Response<string>(HttpStatusCode.BadRequest, "Failed");
        
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<bool>> DeleteMentorGroupAsync(int id)
    {
        try
        {

        var sql = $"Delete from mentorgroup where id = {@id}";
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