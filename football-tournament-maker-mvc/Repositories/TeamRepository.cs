using football_tournament_maker_mvc.Data;
using football_tournament_maker_mvc.Models;
using football_tournament_maker_mvc.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace football_tournament_maker_mvc.Repositories
{
    public class TeamRepository : IRepository<Team>
    {
        private readonly AppDbContext _context;
        public TeamRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Team team)
        {

            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == id);
            if (team != null)
                _context.Teams.Remove(team);
           
            
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            return await _context.Teams.ToListAsync();

        }

        public async Task<Team> GetByIdAsync(int id)
        {
           return await _context.Teams.Include(x=>x.TeamDetail).FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Teams.AnyAsync(t => t.Name == name);
        }


    }
}
