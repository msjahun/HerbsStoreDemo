using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HerbsStore.Libraries.HS.Services.Security
{
    public class PermissionService : IPermissionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PermissionService(
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
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
    }
}
