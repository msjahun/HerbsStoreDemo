namespace HerbsStore.Libraries.HS.Services.Security
{
    public interface IPermissionService
    {
        bool AuthorizeAdministrator();
        bool Authorize();
    }
}