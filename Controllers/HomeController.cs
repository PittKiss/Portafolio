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
			var proyectos = ObtenerProyectos().Take(6).ToList();
			var modelo = new HomeInicioViewModel { Proyectos = proyectos };
			ViewBag.Tipo = "Minion ";
			return View("Inicio", modelo);
		}
		private List<Proyecto> ObtenerProyectos() {

			return new List<Proyecto> {
				new Proyecto { Titulo = "Kungfu Pandih", Descripcion = "Hago Kungfu", Link="https://www.twitch.tv", ImagenURL="/img/kungfu.jpg"},
				new Proyecto { Titulo = "Putazo", Descripcion = "Te muerdo y te pego", Link="https://www.twitch.tv", ImagenURL="/img/putazo.jpg"},
				new Proyecto { Titulo = "Zing", Descripcion = "Te hago un zing horendo", Link="https://www.twitch.tv", ImagenURL="/img/zing.jpg"},
				new Proyecto { Titulo = "Pandih en bikini", Descripcion = "Te digo 'Pandih en bikini tomando un martini'", Link="https://www.twitch.tv", ImagenURL="/img/bikini.jpg"},
				new Proyecto { Titulo = "Pandih minipekka", Descripcion = "Te digo 'aña'", Link="https://www.twitch.tv", ImagenURL="/img/aña.jpg"},
				new Proyecto { Titulo = "Pandih se va", Descripcion = "Me pongo la capucha y me voy por lo alto", Link="https://www.twitch.tv", ImagenURL="/img/capucha.gif"}
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