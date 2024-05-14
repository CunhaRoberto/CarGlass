using Microsoft.EntityFrameworkCore;
using PassIn.Infrastructure.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PassIn.Infrastructure
{
    public class PassInDbContext : DbContext{
       
       
        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }

        protected override void OnConfiguring(
             DbContextOptionsBuilder optionsBuilder)
               => optionsBuilder.UseSqlServer(connectionString: "Server = tcp:rcunha.database.windows.net, 1433; Initial Catalog = cunha_database; Persist Security Info=False;User ID = rcunha_db; Password=Rgf980711;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;",
                   sqlServerOptions => sqlServerOptions.EnableRetryOnFailure());      
   
    }
  }