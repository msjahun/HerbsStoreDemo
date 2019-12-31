using HerbsStore.Libraries.HS.Services.HospitalServices;
using Microsoft.AspNetCore.Mvc;

namespace HerbsStore.Controllers
{
    public class HospitalsController : Controller
    {
        private IHospitalService _hospitalService;

        public HospitalsController(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        public IActionResult List(HospitalCrudVm vm)
        {
            var model = new HospitalCrudVm {List = _hospitalService.GetHospitals(vm)};
            return View(model);
        }
    }
}