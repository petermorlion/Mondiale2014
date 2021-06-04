using RestSharp;
using RestSharp.Authenticators;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace KotProno2.Services
{
    public interface IMailgunService
    {
        Task SendMail(string email, string subject, string body);
    }

    public class MailgunService : IMailgunService
    {
        private readonly ILogger _logger;

        public MailgunService(ILogger logger)
        {
            _logger = logger;
        }

        public async Task SendMail(string email, string subject, string body)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri("https://api.eu.mailgun.net/v3"),
                Authenticator = new HttpBasicAuthenticator("api", System.Configuration.ConfigurationManager.AppSettings["MailgunApiKey"])
            };

            var request = new RestRequest();
			request.AddParameter("domain", "mg.kotprono.be", ParameterType.UrlSegment);
			request.Resource = "{domain}/messages";
			request.AddParameter("from", "KotProno <mailgun@kotprono.be>");
			request.AddParameter("to", email);
			request.AddParameter("subject", subject);
			request.AddParameter("html", body);
			request.Method = Method.POST;
			
			var response = await client.ExecuteAsync(request);

            var statusCodeNumber = (int)response.StatusCode;
            if (statusCodeNumber < 200 || statusCodeNumber > 399)
            {
                _logger.Error($"An error occurred when calling Mailgun. Received a {response.StatusCode} and the following content: {response.Content}. ErrorMessage: {response.ErrorMessage}. ErrorException: {response.ErrorException}");
            }
        }
    }
}