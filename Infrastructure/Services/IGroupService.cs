using Domain.Models;
using Domain.Responses;

namespace Infrastructure.Services;

public interface IGroupService
{
    Task<Response<List<Group>>> GetGroupsAsync();
    Task<Response<Group>> GetGroupByIdAsync(int id);
    Task<Response<string>> CreateGroupAsync(Group group);
    Task<Response<string>> UpdateGroupAsync(Group group);
    Task<Response<bool>> DeleteGroupAsync(int id);
}