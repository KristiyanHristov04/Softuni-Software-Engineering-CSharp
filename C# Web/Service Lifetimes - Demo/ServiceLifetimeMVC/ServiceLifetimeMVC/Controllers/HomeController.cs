using Microsoft.AspNetCore.Mvc;
using ServiceLifetimeMVC.Interfaces;
using ServiceLifetimeMVC.Models;
using ServiceLifetimeMVC.Services;
using System.Diagnostics;

namespace ServiceLifetimeMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IScopedService scopedService;
        private readonly ITransientService transientService;
        private readonly ISingletonService singletonService;

        public HomeController(
            IScopedService scopedService,
            ITransientService transientService, 
            ISingletonService singletonService)
        {
            this.scopedService = scopedService;
            this.transientService = transientService;
            this.singletonService = singletonService;
        }

        public IActionResult Index()
        {
            ViewBag.TransientInstanceId = transientService.GetInstanceId();
            ViewBag.ScopedInstanceId = scopedService.GetInstanceId();
            ViewBag.SingletonInstanceId = singletonService.GetInstanceId();

            return View();
        }

        public IActionResult Scoped()
        {
            ViewBag.ScopedInstance = scopedService.GetInstanceId();

            return View();
        }

        public IActionResult Transient()
        {
            ViewBag.TransientInstance = transientService.GetInstanceId();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}