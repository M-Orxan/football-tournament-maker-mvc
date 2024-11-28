using System.ComponentModel.DataAnnotations;

namespace football_tournament_maker_mvc.ViewModels
{
    public class CreateTeamVM
    {
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
    }
}
