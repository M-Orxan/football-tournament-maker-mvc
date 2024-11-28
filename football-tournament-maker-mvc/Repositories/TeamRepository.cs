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
            var exists = await _context.Teams.AnyAsync(t => t.Name == team.Name);
            if (exists)
            {

            }
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            return await _context.Teams.ToListAsync();

        }

        public Task<Team> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Teams.AnyAsync(t => t.Name == name);
        }


    }
}
