using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sandbox.Models;

namespace Sandbox.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly IWebHostEnvironment environment; 

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment host)
        {
            _logger = logger;
			this.environment = host; 
        }

        public IActionResult Index()
        {
			string libPath = Path.Combine(this.environment.WebRootPath, "lib");
			string file = Directory.GetFiles(libPath).FirstOrDefault();
			ViewBag.Script = Path.GetFileName(file);
			
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
