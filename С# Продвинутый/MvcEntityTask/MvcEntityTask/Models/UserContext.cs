using System.Data.Entity;

namespace MvcEntityTask.Models
{
    public class UserContext : DbContext
    {
        public UserContext() : base("DbUsersV3")
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Review> Reviews { get; set; }
    }
}