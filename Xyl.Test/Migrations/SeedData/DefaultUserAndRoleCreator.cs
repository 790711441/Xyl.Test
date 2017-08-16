using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Xyl.Test.Models;

namespace Xyl.Test.Migrations.SeedData
{
    public class DefaultUserAndRoleCreator
    {
        private readonly ApplicationDbContext _context;

        public DefaultUserAndRoleCreator(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create()
        {
            //Role
            await AddRoleIfNotExists("admin", "超级管理员");

            //User
            await AddUserIfNotExists("790711441@qq.com", "向玉林", "!aA147258");
            await AddUserIfNotExists("aa@qq.com", "向玉林", "!aA147258");

            //UserRole
            await AddUserRoleIfNotExists("790711441@qq.com", "admin");
            await AddUserRoleIfNotExists("aa@qq.com", "admin");

            return true;
        }

        private async Task<bool> AddRoleIfNotExists(string name, string showName)
        {
            var manager = ApplicationRoleManager.Create(_context);

            bool isExists = await manager.RoleExistsAsync(name);
            if (isExists)
                return true;


            var result = await manager.CreateAsync(new ApplicationRole { Id = Guid.NewGuid().ToString().ToUpper(), Name = name, ShowName = showName });
            return true;
        }

        private async Task<bool> AddUserIfNotExists(string name, string showName, string password)
        {
            var manager = ApplicationUserManager.Create(_context);

            var user = await manager.FindByNameAsync(name);
            if (user != null)
            {
                return true;
            }

            var result = await manager.CreateAsync(new ApplicationUser { Id = Guid.NewGuid().ToString().ToUpper(), UserName = name, Email = name, ShowName = showName }, password);

            return true;
        }

        private async Task<bool> AddUserRoleIfNotExists(string name, string role)
        {
            var userManager = ApplicationUserManager.Create(_context);
            var roleManager = ApplicationRoleManager.Create(_context);

            var user = await userManager.FindByNameAsync(name);
            if (user == null)
            {
                return true;
            }

            var roles = from a in user.Roles
                        join b in roleManager.Roles on a.RoleId equals b.Id
                        select b;

            if (roles.Where(p => p.Name == role).Count() > 0)
            {
                return true;
            }

            await userManager.AddToRoleAsync(user.Id, role);
            return true;
        }
    }
}