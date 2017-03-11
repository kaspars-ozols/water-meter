using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using WaterMeter.Core.Persistance;
using WaterMeter.Services.Mail;
using WaterMeter.Services.Templating;
using WaterMeter.WebJobs.Models;

namespace WaterMeter.WebJobs.Jobs
{
    public class ReminderJob
    {
        private readonly ITemplateRenderer _templateRenderer;
        private readonly IMailService _mailService;

        public ReminderJob(ApplicationDbContext dbContext, ITemplateRenderer templateRenderer, IMailService mailService)
        {
            _templateRenderer = templateRenderer;
            _mailService = mailService;
        }

        public Task Execute([TimerTrigger("00:00:10")] TimerInfo timer)
        {
            var model = new ReminderModel
            {
                FirstName = "Kaspars",
                LastName = "Ozols",
                Link = "http://google.com",
                Properties = new List<PropertyModel>
                {
                    new PropertyModel
                    {
                        Name = "Dižbārdu 15",
                        Address = "Dižbārdu 15",
                        Meters = new List<MeterModel>
                        {
                            new MeterModel
                            {
                                SerialNumber = "123",
                                LastReadingDate = DateTime.Now.AddMonths(-1),
                                LastReadingValue = 1234.567m
                            }
                        }
                    }
                }
            };

            var mailMessage = new MailMessage
            {
                From = ReminderJobConfig.Sender,
                // TODO: replace with user email
                To = ReminderJobConfig.Sender,
                Subject = "Reminder",
                Body = _templateRenderer.Render(@"Templates\EmailReminder.cshtml", model)
            };

            _mailService.Send(mailMessage);

            //if (!timer.IsPastDue)
            //{
            //    var userRole = _dbContext.Roles
            //        .FirstOrDefault(x => x.Name == Role.User);

            //    if(userRole == null)
            //        throw new NullReferenceException(nameof(userRole));

            //    var users = _dbContext.Users
            //        .Where(x => x.Roles.Any(r => r.RoleId == userRole.Id))
            //        .ToList();

            //    foreach (var user in users)
            //    {
            //        var properties = user.Properties.ToList();

            //        foreach (var property in properties)
            //        {

            //        }
            //    }
            //}

            return Task.CompletedTask;
        }

    }
}