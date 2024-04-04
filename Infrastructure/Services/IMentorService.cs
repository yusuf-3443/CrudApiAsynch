using Domain.Models;
using Domain.Responses;

namespace Infrastructure.Services;

public interface IMentorService
{
    Task<Response<List<Mentor>>> GetMentorsAsync();
    Task<Response<Mentor>> GetMentorByIdAsync(int id);
    Task<Response<string>> CreateMentorAsync(Mentor mentor);
    Task<Response<string>> UpdateMentorAsync(Mentor mentor);
    Task<Response<bool>> DeleteMentorAsync(int id);
}