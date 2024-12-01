using football_tournament_maker_mvc.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace football_tournament_maker_mvc.ViewModels
{
    public class MatchVM
    {
        //public int HomeTeamId { get; set; }
        //public int AwayTeamId { get; set; }

        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
    }
}
