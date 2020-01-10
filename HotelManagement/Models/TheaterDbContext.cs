using TheaterTicketsManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheaterTicketsManagement
{
    public class TheaterDbContext : DbContext
    {

        public DbSet<Play> Plays { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Seat> Seats { get; set; }

        public DbSet<AppUser> Users { get; set; }
     /*   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=hotel;");
        }*/

            public TheaterDbContext(DbContextOptions options) : base(options) {}
        public TheaterDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(x => x.Id);

                
                entity.HasOne(x => x.Seat)
                    .WithMany(x => x.Reservations)
                    .HasForeignKey(x => x.SeatId);

                entity.HasOne(x => x.Play)
                    .WithMany(x => x.Reservations)
                    .HasForeignKey(x => x.PlayId);
           
                entity.HasOne(x => x.AppUser)
                    .WithMany(x => x.Reservations)
                    .HasForeignKey(x => x.AppUserId);
            });

            modelBuilder.Entity<Seat>(entity =>
            {
                entity.HasKey(x => x.Id);
            });

            modelBuilder.Entity<Play>(entity =>
           {
               entity.HasKey(x => x.Id);
           });

            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasIndex(x => x.UserName).IsUnique();
            });
        }
    }
}
