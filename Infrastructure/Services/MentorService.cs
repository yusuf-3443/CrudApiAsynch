using System.Net;
using Dapper;
using Domain.Models;
using Domain.Responses;
using Infrastructure.DataContext;

namespace Infrastructure.Services;

public class MentorService : IMentorService
{
    private readonly DapperContext _context;

    public MentorService(DapperContext context)
    {
        _context = context;
    }

     public async Task<Response<List<Mentor>>> GetMentorsAsync()
    {
        try
        {
            var sql = $@"Select * from Mentor";
            var result = await _context.Connection().QueryAsync<Mentor>(sql);
            return new Response<List<Mentor>>(result.ToList());
        }
        catch (Exception e)
        {
            return new Response<List<Mentor>>(HttpStatusCode.InternalServerError, e.Message);
        }  
    }

    public async Task<Response<Mentor>> GetMentorByIdAsync(int id)
    {
        try
        {
            var sql = $@"Select * from Mentor where id={@id}";
            var result = await _context.Connection().QueryFirstOrDefaultAsync<Mentor>(sql);
            if (result != null) return new Response<Mentor>(result);
            return new Response<Mentor>(HttpStatusCode.BadRequest,"Not Found");
        }
        catch (Exception e)
        {
            return new Response<Mentor>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> CreateMentorAsync(Mentor mentor)
    {
        try
        {
            var sql = $@"Insert into Mentor(firstname,lastname,email,phone,address,city)
                  values('{mentor.Firstname}', {mentor.Lastname}, '{mentor.Email}','{mentor.Phone}','{mentor.Address}','{mentor.City}')";
            var result = await _context.Connection().ExecuteAsync(sql);
            if(result>0) return new Response<string>("Successfully created Mentor");
            return new Response<string>(HttpStatusCode.BadRequest, "Couldn't create Mentor'");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<string>> UpdateMentorAsync(Mentor mentor)
    {
        try
        {
            var sql = $@"Update MENTOR SET firstname = '{mentor.Firstname}',lastname = '{mentor.Lastname}',email = '{mentor.Email}',
                  phone = '{mentor.Phone}',address = '{mentor.Address}',city = '{mentor.City}' 
               where id={mentor.Id}";
            var result=  await _context.Connection().ExecuteAsync(sql);
            
            if(result>0) return new Response<string>("Successfully updates Mentor");
            return new Response<string>(HttpStatusCode.BadRequest, "Couldn't update Mentor'");
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteMentorAsync(int id)
    {
        try
        {
            var sql = @$"delete from mentor where id={@id}";
            var result = await _context.Connection().ExecuteAsync(sql);
            if(result>0) return new Response<bool>(true);
            return new Response<bool>(HttpStatusCode.BadRequest, "Couldn't delete Mentor'");
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
}