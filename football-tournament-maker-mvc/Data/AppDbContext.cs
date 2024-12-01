using football_tournament_maker_mvc.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace football_tournament_maker_mvc.Data
{
    public class AppDbContext:IdentityDbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {
            
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<TeamTournament> TeamTournaments { get; set; }
        public DbSet<TeamDetail> TeamDetails { get; set; }
        public DbSet<Match> Matches { get; set; }
    }
}
