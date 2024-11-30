using football_tournament_maker_mvc.Data;
using football_tournament_maker_mvc.Models;
using football_tournament_maker_mvc.Repositories;
using football_tournament_maker_mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace football_tournament_maker_mvc.Controllers
{
    public class TournamentsController : Controller
    {
        private readonly IRepository<Tournament> _repository;
        private readonly AppDbContext _context;

        public TournamentsController(IRepository<Tournament> repository, AppDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tournaments=await _repository.GetAllAsync();
            var vm = tournaments.Select(t => new TournamentVM
            {
                Name = t.Name
            }).ToList();

            return View(vm);
        }
    }
}
