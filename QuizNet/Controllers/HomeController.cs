using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuizNet.Models;

namespace QuizNet.Controllers
{
    public class HomeController : Controller
    {
        public static List<Student> students = new List<Student>()
        {
            new Student()
            {
                Id=1,
                Index=123456,
                FirstName = "Daniel",
                LastName = "Wilkiewicz"

            },
            new Student()
            {
                Id=2,
                Index=35453,
                FirstName = "Krzysztof",
                LastName = "Milewski"

            },
    };

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int id=1)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            return View(student);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
