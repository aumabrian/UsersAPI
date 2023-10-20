using Microsoft.EntityFrameworkCore;
using UsersAPI.Models;

namespace UsersAPI.Data
{
    public class UsersAPIDbContext : DbContext
    {
        public UsersAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
