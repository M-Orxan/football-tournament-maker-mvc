using System.ComponentModel.DataAnnotations;

namespace football_tournament_maker_mvc.Models
{
    public class Team
    {
        public int Id { get; set; }
      
        public string Name { get; set; }

        public int PlayedGames { get; set; }
        public int Points { get; set; }
        public int Won { get; set; }
        public int Drawn { get; set; }
        public int Lost { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference { get; set; }

        public List<TeamTournament> TeamTournaments { get; set; }
        public TeamDetail TeamDetail { get; set; }
    }
}
