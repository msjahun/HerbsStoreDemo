﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HerbsStore.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Checkout()
        {
            return View();
        }
    }
}