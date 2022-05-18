using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Areas.Admin.Models;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IProduct ipro;

        public HomeController(IProduct Ipro)
        {
            ipro = Ipro;
        }
        public IActionResult Index()
        {
            List<products> product = ipro.GetProducts().ToList();
            return View(product);
        }


       
    }
}
