using FriendsHub.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsHub.Services.Data
{
    public interface IFriendLookupService
    {
        Task<IEnumerable<LookupItem>> GetAllAsync();
    }
}