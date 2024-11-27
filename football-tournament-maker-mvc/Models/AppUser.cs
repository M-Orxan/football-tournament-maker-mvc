using Microsoft.AspNetCore.Identity;

namespace football_tournament_maker_mvc.Models
{
    public class AppUser:IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        public string Email { get; set; }
        
    }
}
