namespace football_tournament_maker_mvc.Models
{
    public class TeamTournament
    {
        public int Id { get; set; }

        public int TeamId { get; set; }

        public Team Team { get; set; }

        public int TournamentId { get; set; }

        public Tournament Tournament { get; set; }
    }
}
