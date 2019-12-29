using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HerbsStore.Libraries.HS.Services.DropdownServices
{
    public interface IDropdownService
    {
        List<SelectListItem> ProductsTypes();
        string ResolveDropdown(int id, List<SelectListItem> dropdownList);
    }
}