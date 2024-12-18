﻿using football_tournament_maker_mvc.Enums;

namespace football_tournament_maker_mvc.Models
{
    public class Tournament
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<TeamTournament> TeamTournaments { get; set; }
        public TournamentFormat TournamentFormat { get; set; }
    }
}
