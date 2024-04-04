using Domain.Models;
using Domain.Responses;

namespace Infrastructure.Services;

public interface IMentorGroupService
{
    Task<Response<List<MentorGroup>>> GetMentorGroupsAsync();
    Task<Response<MentorGroup>> GetMentorGroupByIdAsync(int id);
    Task<Response<string>> CreateMentorGroupAsync(MentorGroup mentorGroup);
    Task<Response<string>> UpdateMentorGroupAsync(MentorGroup mentorGroup);
    Task<Response<bool>> DeleteMentorGroupAsync(int id);
}