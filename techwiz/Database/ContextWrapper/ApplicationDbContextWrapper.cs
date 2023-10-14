using Microsoft.EntityFrameworkCore;
using TechWiz.Models;

namespace TechWiz.Database.ContextWrappers
{
    public class ApplicationDbContextWrapper : IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationDbContextWrapper(DbSet<User> users)
        {
            Users = users;
        }
    }
}