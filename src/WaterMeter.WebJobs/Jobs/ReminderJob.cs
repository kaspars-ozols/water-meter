using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using WaterMeter.Core.Constants;
using WaterMeter.Core.Entities;
using WaterMeter.Core.Persistance;
using WaterMeter.Services.Mail;
using WaterMeter.Services.Templating;
using WaterMeter.WebJobs.Models;

namespace WaterMeter.WebJobs.Jobs
{
    public class ReminderJob
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ITemplateRenderer _templateRenderer;
        private readonly IMailService _mailService;

        public ReminderJob(ApplicationDbContext dbContext, ITemplateRenderer templateRenderer, IMailService mailService)
        {
            _dbContext = dbContext;
            _templateRenderer = templateRenderer;
            _mailService = mailService;
        }

        public Task Execute([TimerTrigger("00:00:10")] TimerInfo timer)
        {
            var utcNow = DateTime.UtcNow;
            var thisMonthStart = new DateTime(utcNow.Year, utcNow.Month, 1, 0, 0, 0, DateTimeKind.Utc);

            var metersWithNoReading = _dbContext
                .Meters
                .Select(m => new
                {
                    Meter = m,
                    LastReading = m.Readings.OrderByDescending(r => r.Date).FirstOrDefault()
                })
                .Where(x => x.LastReading == null || x.LastReading.Date < thisMonthStart)
                .ToList();

            var propertiesWithNoReading = metersWithNoReading
                .Select(x => x.Meter.Property)
                .Distinct()
                .ToList();

            var userRole = _dbContext.Roles.Single(x => x.Name == Role.User);

            var usersWithNoReading = propertiesWithNoReading
                .SelectMany(p => p.Users)
                .Where(u => u.Roles.Any(r => r.RoleId == userRole.Id))
                .Distinct()
                .ToList();

            var reminders = usersWithNoReading
                .Select(u => new ReminderModel
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Link = "google.com",

                    Properties = propertiesWithNoReading
                    .Where(p => p.Users.Contains(u))
                    .Select(p => new PropertyModel
                    {
                        Name = p.Name,
                        Address = p.Address,
                        Meters = metersWithNoReading
                            .Select(m => new MeterModel
                            {
                                SerialNumber = m.Meter.SerialNumber,
                                LastReadingValue = m.LastReading?.Value,
                                LastReadingDate = m.LastReading?.Date
                            })
                            .ToList()
                    })
                    .ToList()
                });

            foreach (var reminder in reminders)
            {
                var mailMessage = new MailMessage
                {
                    From = ReminderJobConfig.Sender,
                    To = reminder.Email,
                    Subject = "Reminder",
                    Body = _templateRenderer.Render(@"Templates\EmailReminder.cshtml", reminder)
                };

                _mailService.Send(mailMessage);
            }

            return Task.CompletedTask;
        }
        
    }
}