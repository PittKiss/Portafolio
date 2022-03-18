using Portafolio.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Portafolio.Servicios
{
	public interface IServiciosEmail
	{
		Task SendEmail(ContactoViewModel contacto);
	}
	public class Email : IServiciosEmail
    {
        private readonly IConfiguration configuration;

        public Email(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SendEmail(ContactoViewModel contacto)
        {

            var apiKey = configuration.GetValue<string>("SENDGRID_API");
            var email = configuration.GetValue<string>("SENDGRID_EMAIL_FROM");
            var nombre = configuration.GetValue<string>("SENDGRID_NOMBRE");

            var cliente = new SendGridClient(apiKey);
            var from = new EmailAddress(email, nombre);
            var subject = $"El cliente {contacto.Nombre} quiere contactarte";
            var to = new EmailAddress(email, nombre);
            ; var mensaje = contacto.Mensaje;
            var contenidoHTML = @$"De {contacto.Nombre} - 
                                Email:{contacto.Email}
                                Mensaje:{contacto.Mensaje}";
            var singleEmail = MailHelper.CreateSingleEmail(from,to,subject,mensaje,contenidoHTML);
            var respuesta = await cliente.SendEmailAsync(singleEmail);

        }
    }
}
