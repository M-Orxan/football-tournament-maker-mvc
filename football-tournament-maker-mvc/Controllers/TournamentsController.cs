using football_tournament_maker_mvc.Data;
using football_tournament_maker_mvc.Enums;
using football_tournament_maker_mvc.Models;
using football_tournament_maker_mvc.Repositories;
using football_tournament_maker_mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var tournaments = await _repository.GetAllAsync();
            var vm = tournaments.Select(t => new TournamentVM
            {
                Id = t.Id,
                Name = t.Name,
                TeamTournaments = t.TeamTournaments,
                TournamentFormat = t.TournamentFormat,

            }).ToList();


            return View(vm);
        }


        public async Task<IActionResult> Create()
        {
            ViewBag.Teams = await _context.Teams.OrderBy(x => x.Name).ToListAsync();
            return View();
        }



        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(CreateTournamentVM vm, int[] teamIds, TournamentFormat format)
        {
            if (!ModelState.IsValid) { return View(vm); }
            ViewBag.Teams = await _context.Teams.OrderBy(x => x.Name).ToListAsync();

            Tournament tournament = new Tournament()
            {
                Name = vm.Name,
                TournamentFormat = format,
                TeamTournaments = teamIds.Select(teamId => new TeamTournament { TeamId = teamId }).ToList()
            };

            await _repository.AddAsync(tournament);

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




        public async Task<IActionResult> GenerateMatches(int id)
        {
            Tournament tournament = await _repository.GetByIdAsync(id);

            if (tournament.TournamentFormat == Enums.TournamentFormat.SingleRoundRobin)
            {
                if (tournament.TeamTournaments.Count % 2 == 0)
                    ViewBag.RoundsCount = tournament.TeamTournaments.Count - 1;
                else
                    ViewBag.RoundsCount = tournament.TeamTournaments.Count;
            }

            int roundsCount;
       
            
            if (tournament.TeamTournaments.Count % 2 == 0)
                roundsCount = tournament.TeamTournaments.Count - 1;
            else
                roundsCount = tournament.TeamTournaments.Count;


            List<MatchVM> matchesVM = new List<MatchVM>();

            for (int i = 0; i < roundsCount; i++)
            {
                for (int j = 0; j < tournament.TeamTournaments.Count / 2; j++)
                {
                    TeamTournament homeTeam = tournament.TeamTournaments[j];

                    TeamTournament awayTeam = tournament.TeamTournaments[tournament.TeamTournaments.Count - 1 - j];
                    MatchVM matchVM = new MatchVM()
                    {
                        HomeTeam = homeTeam.Team,
                        AwayTeam = awayTeam.Team,

                    };
                    matchesVM.Add(matchVM);
                }
               
                TeamTournament lastTeam = tournament.TeamTournaments[tournament.TeamTournaments.Count - 1];

                if (tournament.TeamTournaments.Count % 2 == 0)
                {
                    tournament.TeamTournaments.Remove(lastTeam);
                    tournament.TeamTournaments.Insert(1, lastTeam);
                }
                else
                {
                    tournament.TeamTournaments.Remove(lastTeam);
                    tournament.TeamTournaments.Insert(0, lastTeam);

                }
            }

            return View(matchesVM);
        }
    }
}
