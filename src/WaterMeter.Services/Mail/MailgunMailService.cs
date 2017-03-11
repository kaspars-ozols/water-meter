using System;
using System.Net;
using RestSharp;
using RestSharp.Authenticators;

namespace WaterMeter.Services.Mail
{
    public class MailgunMailService : IMailService
    {
        public bool Send(MailMessage mailMessage)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri(MailgunConfig.BaseUrl),
                Authenticator = new HttpBasicAuthenticator("api", MailgunConfig.ApiKey)
            };
            var request = new RestRequest();
            request.AddParameter("domain", MailgunConfig.Domain, ParameterType.UrlSegment);
            request.Resource = $"{MailgunConfig.Domain}/messages";
            request.AddParameter("from", mailMessage.From);
            request.AddParameter("to", mailMessage.To);
            request.AddParameter("subject", mailMessage.Subject);
            request.AddParameter("html", mailMessage.Body);
            request.Method = Method.POST;

            var response = client.Execute(request);

            return response.StatusCode == HttpStatusCode.OK;
        }
    }
}