using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.Entities
{
    public class DatabaseContext : DbContext
    {
        public DbSet<TeamDomain> Teams { get; set; }
        public DbSet<UserDomain> Users { get; set; }
        public DbSet<ExerciseDomain> Exercises { get; set; }
        public DbSet<CompetitionDomain> Competitions { get; set; }
        public DbSet<EventDomain> Events { get; set; }
        public DbSet<GameDomain> Games { get; set; }
        public DbSet<AnnouncementDomain> Announcements { get; set; }
        public DbSet<ButtonsDomain> Buttons { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SportsTeamManagementAppDB;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamDomain>(team =>
            {
                team.HasOne(t => t.Buttons)
                    .WithOne(b => b.Team)
                    .HasForeignKey<ButtonsDomain>(b => b.TeamId);

                team.HasMany(t => t.Announcements)
                    .WithOne(a => a.Team)
                    .HasForeignKey(a => a.TeamId);

                team.HasMany(t => t.Events)
                    .WithOne(e => e.Team)
                    .HasForeignKey(e => e.TeamId);

                team.HasMany(t => t.Competitions)
                    .WithOne(c => c.Team)
                    .HasForeignKey(c => c.TeamId);

                team.HasMany(t => t.Users)
                    .WithOne(u => u.Team)
                    .HasForeignKey(u => u.TeamId);
            });

            modelBuilder.Entity<EventDomain>()
                .HasMany(e => e.Games)
                .WithOne(g => g.Event)
                .HasForeignKey(g => g.EventId);

            modelBuilder.Entity<CompetitionDomain>()
                .HasMany(c => c.Exercises)
                .WithOne(e => e.Competition)
                .HasForeignKey(e => e.CompetitionId);

            modelBuilder.Entity<UserDomain>()
                .HasMany(u => u.Exercises)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId);

        }


    }
}
