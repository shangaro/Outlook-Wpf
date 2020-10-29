using FriendsHub.Data;
using FriendsHub.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsHub.Services.Data
{
    public class LookupService : IFriendLookupService
    {
        private readonly CatalogContext _context;

        public LookupService(CatalogContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<LookupItem>> GetAllAsync()
        {

            var items = await _context.Friends.AsNoTracking().Select(fr => new LookupItem
            {
                Id = fr.FriendId,
                DisplayName = $"{ fr.FirstName} {fr.LastName}"
            }).ToListAsync();
            return items;

        }
    }
}
