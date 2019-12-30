using HerbsStore.Libraries.HS.Core.Domain.Users;

namespace HerbsStore.Libraries.HS.Services.Security
{
    public interface IPermissionService
    {
        bool AuthorizeAdministrator();
        bool Authorize();
        User GetCurrentUser();
    }
}