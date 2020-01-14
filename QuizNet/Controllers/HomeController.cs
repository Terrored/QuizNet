using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using QuizNet.Models;
using System;
using System.Diagnostics;

namespace QuizNet.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache _cache;

        public HomeController(ILogger<HomeController> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult CacheTest()
        {
            //  SPOSÓB 1

            //if (!_cache.TryGetValue("Current time", out DateTime result))
            //{
            //    result = DateTime.Now;

            //    _cache.Set("Current time", result);
            //}
            //return Content(result.ToString());



            // SPOSÓB 2
            var cacheItem = _cache.GetOrCreate("Current time", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10);
                entry.SlidingExpiration = TimeSpan.FromSeconds(3);
                return DateTime.Now;
            });
            return Content(cacheItem.ToString());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
