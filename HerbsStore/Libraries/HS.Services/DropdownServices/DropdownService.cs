using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HerbsStore.Libraries.HS.Services.DropdownServices
{
    public class DropdownService : IDropdownService
    {

        public List<SelectListItem> ProductsTypes()
        {
            var model = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = "1",
                    Text = "Fruits"
                },
                new SelectListItem
                {
                    Value = "2",
                    Text = "Herbs"
                }
            };
            return model;
        }
        public string ResolveDropdown(int id, List<SelectListItem> dropdownList)
        {
            foreach (var item in dropdownList)
            {
                if (item.Value == id.ToString()) return item.Text;
            }
            return "";
        }


    }
}
