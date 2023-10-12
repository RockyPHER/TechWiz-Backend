using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using TechWiz.Models;

namespace TechWiz.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   
            var conectionString = "Server=backend-db-1;Database=default_schema;User=test;Password=test;Port=3306;";
            optionsBuilder.UseMySql(conectionString, new MySqlServerVersion(new Version(8, 0, 34)));
        }


    }
}