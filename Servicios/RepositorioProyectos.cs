using Portafolio.Models;

namespace Portafolio.Servicios
{
    public class RepositorioProyectos
    {
		public List<Proyecto> ObtenerProyectos()
		{
			return new List<Proyecto> {
				new Proyecto { Titulo = "Kungfu Pandih", Descripcion = "Paso de ser una camarera del restaurante de pasta de mi padre a convertirme en un héroe de artes marciales.", Link="https://www.twitch.tv", ImagenURL="/img/kungfu.jpg"},
				new Proyecto { Titulo = "Putazo", Descripcion = "Te invito a mi casa y en mi sótano te muerdo y te pego.", Link="https://www.twitch.tv", ImagenURL="/img/putazo.jpg"},
				new Proyecto { Titulo = "Zing", Descripcion = "Te hago un zing con tu nombre y un dibujo horrible que te traumará.", Link="https://www.twitch.tv", ImagenURL="/img/zing.jpg"},
				new Proyecto { Titulo = "Pandih en Clash Royale", Descripcion = "Me convierto en una carta de calidad especial en el Clash Royale.", Link="https://www.twitch.tv", ImagenURL="/img/carta.gif"},
				new Proyecto { Titulo = "Pandih japonea", Descripcion = "Me convierto en japonesa y te digo 'aña' y 'onichan'.", Link="https://www.twitch.tv", ImagenURL="/img/aña.jpg"},
				new Proyecto { Titulo = "Pandih se va", Descripcion = "Me pongo la capucha y me voy por lo alto.", Link="https://www.twitch.tv", ImagenURL="/img/capucha.gif"}
			};
		}

	}
}
