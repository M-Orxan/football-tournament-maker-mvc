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
        public Task AddAsync(Tournament entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tournament>> GetAllAsync()
        {
            return await _context.Tournaments.ToListAsync();
        }

        public Task<Tournament> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
