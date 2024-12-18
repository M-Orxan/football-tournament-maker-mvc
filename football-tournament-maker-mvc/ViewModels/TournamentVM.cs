﻿using football_tournament_maker_mvc.Enums;
using football_tournament_maker_mvc.Models;

namespace football_tournament_maker_mvc.ViewModels
{
    public class TournamentVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TeamTournament> TeamTournaments { get; set; }
        public TournamentFormat TournamentFormat { get; set; }
    }
}
