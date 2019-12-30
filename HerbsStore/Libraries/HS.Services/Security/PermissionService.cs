using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using HerbsStore.Libraries.HS.Core.Domain.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace HerbsStore.Libraries.HS.Services.Security
{
    public class PermissionService : IPermissionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public PermissionService(
            IHttpContextAccessor httpContextAccessor,
            UserManager<User> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public bool AuthorizeAdministrator()
        { 
            //if user is authenticated && isadministrator return true;
           
            var user = _httpContextAccessor.HttpContext.User;
            
            return user.Identity.IsAuthenticated && user.IsInRole("Administrator");
        }

        public bool Authorize()
        {
            //if user user is authenticated return true
            var user = _httpContextAccessor.HttpContext.User;
           
            return user.Identity.IsAuthenticated;
        }

        public User GetCurrentUser()
        {

            var user = _httpContextAccessor.HttpContext.User;

            if (user.Identity.IsAuthenticated)
            {

                var userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;
                var User = _userManager.Users.Where(u => u.Id == userId).FirstOrDefault();
                if (User == null) return null;

                return User;
            }
            return null;
        }

    }
}
