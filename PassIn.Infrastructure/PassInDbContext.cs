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
               => optionsBuilder.UseNpgsql(connectionString: "User ID=rcunha_db;Password=TGJjUP5mTPRRHXGHccRMPlxingF0SbWN;Host=dpg-cp38umol6cac73f1uee0-a.oregon-postgres.render.com;Port=5432;Database=rcunha_db;");


    }
  }