using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OfficeReservationService.Contracts.Models;
using OfficeReservationService.Domain;

namespace OfficeReservationService.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public DbSet<Company> Company{ get; set; }
        public DbSet<Room> Room{ get; set; }
        public DbSet<Seating> Seating{ get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Company>()
                .HasMany(x => x.Users)
                .WithOne(x => x.Company)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Company>()
                .HasMany(x => x.Rooms)
                .WithOne(x => x.Company)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Room>()
                .HasMany(x=>x.Seatings)
                .WithOne(x=>x.Room)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}