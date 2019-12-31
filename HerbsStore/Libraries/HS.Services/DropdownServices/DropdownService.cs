using System.Collections.Generic;
using System.Linq;
using HerbsStore.Libraries.HS.Core.Domain.Diseases;
using HerbsStore.Libraries.HS.Data.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HerbsStore.Libraries.HS.Services.DropdownServices
{
    public class DropdownService : IDropdownService
    {
       
        private readonly IRepository<Disease> _diseaseRepo;

        public DropdownService(IRepository<Disease> diseaseRepo)
        {
            _diseaseRepo = diseaseRepo;
        }
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

        public List<SelectListItem> GetDisease()
        {
            var model = from d in _diseaseRepo.List()
                select new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.DiseaseName
                };

            return model.ToList();
        }

    }
}
