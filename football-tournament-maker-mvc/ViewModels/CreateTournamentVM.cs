using football_tournament_maker_mvc.Enums;
using football_tournament_maker_mvc.Models;

namespace football_tournament_maker_mvc.ViewModels
{
    public class CreateTournamentVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public TournamentFormat TournamentFormat { get; set; }

    }
}
