using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Servicios;
using System.Diagnostics;

namespace Portafolio.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
        private readonly IServiciosRepositorio repositorio;

        public HomeController(ILogger<HomeController> logger, IServiciosRepositorio repositorio)
		{
			_logger = logger;
            this.repositorio = repositorio;
        }

		public IActionResult Index()
		{
			
			var proyectos = repositorio.ObtenerProyectos().Take(6).ToList();
			var modelo = new HomeInicioViewModel { Proyectos = proyectos };
			return View("Inicio", modelo);
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