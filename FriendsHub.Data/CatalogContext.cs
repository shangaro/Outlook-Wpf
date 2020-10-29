using FriendsHub.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace FriendsHub.Data
{
    public class CatalogContext:DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options):base(options)
        {

        }

        public DbSet<Friend> Friends { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        
    }
}
