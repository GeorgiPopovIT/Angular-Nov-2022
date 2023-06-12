using GorgesMusic.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace GorgesMusicBackend.Infrastructure
{
    public static class SeedAdmin
    {
        const string AdminRoleName = "Administrator";
        private const string adminEmail = "admin@gmail.com";
        private const string adminPassword = "123456";
        private const string adminUsername = "gorges";
        public static void SeedAdministrator(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task.Run(async () =>
            {
                //if (await roleManager.RoleExistsAsync(AdminRoleName))
                //{
                //    return;
                //}
                var role = new IdentityRole { Name = AdminRoleName };


                var user = new User
                {
                    Email = adminEmail,
                    UserName = adminUsername,
                };

                await userManager.CreateAsync(user, adminPassword);

                await userManager.AddToRoleAsync(user, role.Name);


            })
             .GetAwaiter()
             .GetResult();
        }

    }
}
