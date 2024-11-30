using football_tournament_maker_mvc.Data;
using football_tournament_maker_mvc.Models;
using football_tournament_maker_mvc.Repositories;
using football_tournament_maker_mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace football_tournament_maker_mvc.Controllers
{

    public class TeamsController : Controller
    {
        private readonly IRepository<Team> _repository;
        private readonly AppDbContext _context;

        public TeamsController(IRepository<Team> repository, AppDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var teams = await _repository.GetAllAsync();
            var vm = teams.Select(t => new TeamVM
            {
                Id = t.Id,
                Name = t.Name
            }).ToList();
            return View(vm);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(CreateTeamVM vm)
        {
            if (!ModelState.IsValid) { return View(); }

            var existsByName = await _repository.ExistsByNameAsync(vm.Name);

            if (existsByName)
            {
                ModelState.AddModelError("Name", "A team with this name already exists");
                return View(vm);
            }

            var team = new Team()
            {
                Name = vm.Name,
               
            };
            team.TeamDetail = new TeamDetail()
            {
                TeamId = team.Id,
               
            };


            await _repository.AddAsync(team);

            return RedirectToAction("Index");
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid) { return View(); }

            await _repository.DeleteAsync(id);

            return RedirectToAction("Index");

        }



        public async Task<IActionResult> Detail(int id)
        {
            if (!ModelState.IsValid) { return View(); }
            var team = await _repository.GetByIdAsync(id);

            var vm = new TeamDetailVM()
            {
                Id = team.Id,
                Name = team.Name,
                TotalPlayedGames = team.TeamDetail.TotalPlayedGames,
                TotalDrawn = team.TeamDetail.TotalDrawn,
                TotalGoalDifference = team.TeamDetail.TotalGoalDifference,
                TotalGoalsAgainst = team.TeamDetail.TotalGoalsAgainst,
                TotalGoalsFor = team.TeamDetail.TotalGoalsFor,
                TotalLost = team.TeamDetail.TotalLost,
                TotalPoints = team.TeamDetail.TotalPoints,
                TotalWon = team.TeamDetail.TotalWon,
            };



            return View(vm);

        }
    }
}
