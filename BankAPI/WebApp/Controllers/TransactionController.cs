﻿using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class TransactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
