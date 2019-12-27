using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HerbsStore.Controllers
{
    public class AdministrationController : Controller
    {
        public IActionResult Products()
        {
            return View();
        }

        public IActionResult ProductAdd()
        {
            return View();
        }

        public IActionResult ProductEdit()
        {
            return View();
        }

        public IActionResult Orders()
        {
            return View();
        }

        public IActionResult OrderEdit()
        {
            return View();
        }

        public IActionResult OrderConfirm()
        {
            return View();
        }



        public IActionResult Hospitals()
        {
            return View();
        }
    }
}