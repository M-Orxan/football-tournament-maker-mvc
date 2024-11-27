
using football_tournament_maker_mvc.Data;
using football_tournament_maker_mvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace football_tournament_maker_mvc.Utilities
{
    public class DbInitializer : IDbInitializer
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;

        public DbInitializer(RoleManager<IdentityRole> roleManager,
                             UserManager<AppUser> userManager, AppDbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }
        public async Task InitializeAsync()
        {

            if (!await _roleManager.RoleExistsAsync(Role.Admin))
            {
                await _roleManager.CreateAsync(new IdentityRole(Role.Admin));
                await _roleManager.CreateAsync(new IdentityRole(Role.User));


                var result = await _userManager.CreateAsync(new AppUser()
                {
                    FirstName = "Orxan",
                    LastName = "Mustafayev",
                    Email = "orxanm385@gmail.com",
                    UserName = "Orxan1999"
                }, "Orxan1999.");

                if (result.Succeeded)
                {
                    var adminUser = await _userManager.Users.FirstAsync();
                    await _userManager.AddToRoleAsync(adminUser, Role.Admin);
                }

                
            }


        }
    }
}
