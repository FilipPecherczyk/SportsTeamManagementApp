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


    }
}
