using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class QuizController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
		public IActionResult Instructions()
		{
			return View();
		}
		public IActionResult StartQuiz()
		{
			return View();
		}
		public IActionResult Score()
		{
			return View();
		}
	}
}
