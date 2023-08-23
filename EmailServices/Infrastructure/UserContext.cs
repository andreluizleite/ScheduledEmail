using EmailServices.Models;
using System.Data.Entity;

namespace EmailServices.Infrastructure
{
    public class UserContext: DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
