using System.Net;
using Dapper;
using Domain.Models;
using Domain.Responses;
using Infrastructure.DataContext;

namespace Infrastructure.Services;

public class GroupService : IGroupService
{
    private readonly DapperContext _context;

    public GroupService(DapperContext context)
    {
        _context = context;
    }

    public async Task<Response<List<Group>>> GetGroupsAsync()
    {
        try
        {

        var sql = $"Select * from group1";
        var result = await _context.Connection().QueryAsync<Group>(sql);
        return new Response<List<Group>>(result.ToList());
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<List<Group>>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<Group>> GetGroupByIdAsync(int id)
    {
        try
        {

        var sql = $"Select * from group1 where id = {@id}";
        var result = await _context.Connection().QueryFirstOrDefaultAsync<Group>(sql);
        if (result != null) return new Response<Group>(result);
        return new Response<Group>(HttpStatusCode.BadRequest, "Group not found");
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<Group>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<string>> CreateGroupAsync(Group group)
    {
        try
        {

        var sql = $"Insert into group1(groupname,groupdescription)" +
                  $"values ('{group.GroupName}','{group.GroupDescription}')";
        var result = await _context.Connection().ExecuteAsync(sql);
        if (result > 0) return new Response<string>("Group successfully added");
        return new Response<string>(HttpStatusCode.BadRequest, "Failed to add group");
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<string>> UpdateGroupAsync(Group group)
    {
        try
        {

        var sql = $"Update group1 " +
                  $"set groupname = '{group.GroupName}',groupdescription = '{group.GroupDescription}'";
        var result = await _context.Connection().ExecuteAsync(sql);
        if (result > 0) return new Response<string>("Group successfully updated");
        return new Response<string>(HttpStatusCode.BadRequest, "Failed to update group");
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
        }

    public async Task<Response<bool>> DeleteGroupAsync(int id)
    {
        try
        {

        var sql = $"Delete from group1 where id = {@id}";
        var result = await _context.Connection().ExecuteAsync(sql);
        if (result > 0) return new Response<bool>(true);
        return new Response<bool>(HttpStatusCode.BadRequest, "Failed to delete group");
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
        }
}