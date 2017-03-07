using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using RazorEngine;
using RazorEngine.Templating;
using WaterMeter.Core.Constants;
using WaterMeter.Core.Persistance;
using WaterMeter.ScheduledJob.Infrastructure;
using WaterMeter.ScheduledJob.Models;
using WaterMeter.ScheduledJob.Rendering;

namespace WaterMeter.ScheduledJob.Jobs
{
    public class RemindersSendingJob
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly RazorRenderer _razorRenderer;

        public RemindersSendingJob(ApplicationDbContext dbContext, RazorRenderer razorRenderer)
        {
            _dbContext = dbContext;
            _razorRenderer = razorRenderer;
        }

        public Task Run([TimerTrigger("00:00:10")] TimerInfo timer)
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

            var email = RenderEmailReminder(model);


            Console.WriteLine(email);

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

        private string RenderEmailReminder(ReminderModel model)
        {
            return _razorRenderer.Render("EmailReminder", model);
        }
    }
}