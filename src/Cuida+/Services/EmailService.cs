using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace Cuida_.Services
{
	public class EmailService
	{
		private readonly IConfiguration _config;

		public EmailService(IConfiguration config)
		{
			_config = config;
		}

		public void Enviar(string para, string assunto, string mensagemHtml)
		{
			var host = _config["EmailSettings:Host"];
			var port = int.Parse(_config["EmailSettings:Port"]);
			var enableSSL = bool.Parse(_config["EmailSettings:EnableSSL"]);
			var user = _config["EmailSettings:User"];
			var password = _config["EmailSettings:Password"];

			var smtp = new SmtpClient(host)
			{
				Port = port,
				EnableSsl = enableSSL,
				Credentials = new NetworkCredential(user, password)
			};

            // new MailMessage(user, para) - usa quando trocar para um email real
			var mail = new MailMessage("no-reply@cuida.com", para)
			{
				Subject = assunto,
				Body = mensagemHtml,
				IsBodyHtml = true
			};

			smtp.Send(mail);
		}
	}
}
