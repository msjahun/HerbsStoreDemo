using System.Threading.Tasks;
using HerbsStore.Libraries.HS.Core.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HerbsStore.Controllers
{
    public class DebugController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<UserRole> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public DebugController(
            UserManager<User> userManager,
            RoleManager<UserRole> roleManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> SeedUsersRoles()
        {
            //if (!_permissionService.Authorize(StandardPermissionProvider.Managedebugpages))
            //    return Unauthorized();




            var customer = new User
            {
                UserName = "Customer@gmail.com",
                Email = "Customer@gmail.com",
                FirstName = "Customer",
                LastName = "_"
            };
            var result = await _userManager.CreateAsync(customer, "HerbStore1#");




            var administrator = new User
            {
                UserName = "Administrator@live.com",
                Email = "Administrator@live.com",
                FirstName = "Admin",
                LastName = "Admin" };
            result = await _userManager.CreateAsync(administrator, "HerbStore1#");


            //create user role and redirect to edit_userRole page
            var role = new UserRole
            {
                Name = "Administrator",
                IsActive = true,
                IsSystemRole = true
            };
            await _roleManager.CreateAsync(role);


            await _userManager.AddToRoleAsync(customer, role.Name);

            await _userManager.AddToRoleAsync(administrator, role.Name);

            //create user role and redirect to edit_userRole page
            role = new UserRole
            {
                Name = "Registered",
                IsActive = true,
                IsSystemRole = true
            };
            await _roleManager.CreateAsync(role);








            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(administrator, false);
                return Json("Roles seeded Successfully");
            }

            return Json("Failed to seed roles");

        }
    }
}