using football_tournament_maker_mvc.Data;
using football_tournament_maker_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace football_tournament_maker_mvc.Repositories
{
    public class TournamentRepository : IRepository<Tournament>
    {
        private readonly AppDbContext _context;
        public TournamentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Tournament entity)
        {
            await _context.Tournaments.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            _context.Remove(await _context.Tournaments.FirstOrDefaultAsync(x=>x.Id==id));

            await _context.SaveChangesAsync();
        }

        public Task<bool> ExistsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tournament>> GetAllAsync()
        {
            return await _context.Tournaments.Include(x=>x.TeamTournaments).ThenInclude(x=>x.Team).ToListAsync();
        }

        public async Task<Tournament> GetByIdAsync(int id)
        {
           return await _context.Tournaments.Include(x => x.TeamTournaments).ThenInclude(x => x.Team).FirstOrDefaultAsync(x=>x.Id==id);
        }
    }
}
