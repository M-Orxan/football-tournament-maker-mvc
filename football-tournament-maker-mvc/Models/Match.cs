using System.ComponentModel.DataAnnotations.Schema;

namespace football_tournament_maker_mvc.Models
{
    public class Match
    {
        public int Id { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }

        
    }
}
