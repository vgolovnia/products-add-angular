using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DMD.Test.Models;
using DMD.Test.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace DMD.Test.Services.DbInit
{
    public class TestUsersInitializer
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly MainContext _dataContext;

        public TestUsersInitializer(MainContext dataContext, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _dataContext = dataContext;
        }

        public async Task GenerateTestUsers()
        {
            var users = new List<User>
            {
                new User{ Email = "admin@mail.test", UserName = "admin", NormalizedUserName = "admin"}
            };

            foreach (var user in users)
            {
                var existUser = await _userManager.FindByEmailAsync(user.Email);
                if (existUser == null)
                {
                    var result = await _userManager.CreateAsync(new User
                    {
                        Email = user.Email,
                        UserName = user.UserName,
                        EmailConfirmed = true,
                    }, user.UserName);

                    if (result.Succeeded)
                    {
                        existUser = await _userManager.FindByEmailAsync(user.Email);
                        await _dataContext.SaveChangesAsync();
                    }
                    else
                    {
                        throw new Exception("Unable to create test user");
                    }
                }
            }
        }
    }
}
