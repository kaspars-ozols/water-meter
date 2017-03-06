using System;
using System.IO;
using Microsoft.Azure.WebJobs;

namespace WaterMeter.ScheduledJob
{
    public class Functions
    {
        // Runs once every 30 seconds
        public static void TimerJob([TimerTrigger("00:00:30")] TimerInfo timer)
        {
            Console.WriteLine("Timer job fired!");
        }
    }
}