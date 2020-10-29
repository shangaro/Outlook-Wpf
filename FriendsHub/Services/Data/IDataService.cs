using FriendsHub.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsHub.Services.Data
{
    public interface IDataService
    {
        Task<IEnumerable<Friend>> GetAllAsync();
        Task<Friend> GetFriendById(int id);
        Task SaveFriendAsync(Friend friend);
    }
}