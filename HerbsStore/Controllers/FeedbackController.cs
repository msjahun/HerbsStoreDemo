using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerbsStore.Libraries.HS.Services.FeedbackServices;
using Microsoft.AspNetCore.Mvc;

namespace HerbsStore.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        } 
        [HttpPost]
        public IActionResult Index(FeedbackCrudVm vm)
        {

            if (!ModelState.IsValid)
                return View(vm);

            _feedbackService.FeedBackAdd(vm);

            return RedirectToAction("Index", "Home");
        }


    }
}