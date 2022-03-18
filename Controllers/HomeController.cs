using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using Portafolio.Servicios;
using System.Diagnostics;

//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

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiciosRepositorio repositorio;
        private readonly IConfiguration configuration;
        private readonly IServiciosEmail servicioEmail;

        public HomeController(ILogger<HomeController> logger, IServiciosRepositorio repositorio, IConfiguration configuration, IServiciosEmail servicioEmail)
        {
            _logger = logger;
            this.repositorio = repositorio;
            this.configuration = configuration;
            this.servicioEmail = servicioEmail;
        }

        public IActionResult Index()
        {
            var nombre = configuration.GetValue<string>("Nombre");
            _logger.LogError("Tu nombre no es " + nombre);
            var proyectos = repositorio.ObtenerProyectos().Take(6).ToList();
            var modelo = new HomeInicioViewModel { Proyectos = proyectos };
            return View("Inicio", modelo);
        }

        public IActionResult Contacto()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Contacto(ContactoViewModel contacto)
        {
            await servicioEmail.SendEmail(contacto);
                return RedirectToAction("Gracias");
        }

        public IActionResult Gracias()
        {
            return View();
        }
        public IActionResult Proyectos()
        {
            var proy = repositorio.ObtenerProyectos();
            return View(proy);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}