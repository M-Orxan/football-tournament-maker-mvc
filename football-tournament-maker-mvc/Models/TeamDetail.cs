namespace football_tournament_maker_mvc.Models
{
    public class TeamDetail
    {
        public int Id { get; set; }
     
       
        public int TotalPlayedGames { get; set; }
        public int TotalPoints { get; set; }
        public int TotalWon { get; set; }
        public int TotalDrawn { get; set; }
        public int TotalLost { get; set; }
        public int TotalGoalsFor { get; set; }
        public int TotalGoalsAgainst { get; set; }
        public int TotalGoalDifference { get; set; }
        public Team Team { get; set; }
        public int TeamId { get; set; }
    }
}
