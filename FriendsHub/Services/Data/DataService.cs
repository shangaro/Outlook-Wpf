using FriendsHub.Data;
using FriendsHub.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FriendsHub.Services.Data
{
    public class DataService : IDataService
    {
        private readonly CatalogContext _context;

        public DataService(CatalogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Friend>> GetAllAsync()
        {
            var friends = await _context.Friends.AsNoTracking().ToListAsync();
            return friends;
        }

        public async Task<Friend> GetFriendById(int id)
        {
            var friend=await _context.Friends.AsNoTracking().SingleOrDefaultAsync(x => x.FriendId == id);
            return friend;
        }
        public async Task SaveFriendAsync(Friend friend)
        {
            _context.Friends.Attach(friend);
            _context.Entry(friend).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
        }
    }
}
