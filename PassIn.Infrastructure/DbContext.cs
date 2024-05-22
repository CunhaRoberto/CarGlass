using Microsoft.EntityFrameworkCore;
using PassIn.Infrastructure.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PassIn.Infrastructure
{
    public class PassInDbContext : DbContext{
       
       
        public DbSet<Event> Events { get; set; }


        protected override void OnConfiguring(
             DbContextOptionsBuilder optionsBuilder)
               => optionsBuilder.UseNpgsql(connectionString: ""); }
  }