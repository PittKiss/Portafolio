using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using System.Diagnostics;

namespace Portafolio.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			var proyectos = ObtenerProyectos().Take(3).ToList();
			var modelo = new HomeInicioViewModel { Proyectos = proyectos };
			ViewBag.Tipo = "Minion ";
			return View("Inicio", modelo);
		}
		private List<Proyecto> ObtenerProyectos() {

			return new List<Proyecto> {
				new Proyecto { Titulo = "Kungfu Pandih", Descripcion = "Hago Kungfu", Link="https://www.twitch.tv", ImagenURL="/img/Panel1.jpg"},
				new Proyecto { Titulo = "Putazo", Descripcion = "Te doy un putazo", Link="https://www.twitch.tv", ImagenURL="/img/Panel2.jpg"},
				new Proyecto { Titulo = "Zing", Descripcion = "Te hago un zing", Link="https://www.twitch.tv", ImagenURL="/img/Panel3.jpg"},
				new Proyecto { Titulo = "Bestia", Descripcion = "Te grito en la oreja", Link="https://www.twitch.tv", ImagenURL="/img/Panel4.jpg"}
			};
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