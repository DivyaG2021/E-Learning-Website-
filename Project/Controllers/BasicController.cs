using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class BasicController : Controller
    {
        public IActionResult HTML()
        {
            return View();
        }
        public IActionResult CSS()
        {
            return View();
        }
    }
}
