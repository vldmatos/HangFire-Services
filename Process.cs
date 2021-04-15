using Hangfire;
using System;

namespace HangFire.Services
{
	public class Process
	{
		private const string cron = "*/5 * * * * *";		

		public static void Start()
		{
			RecurringJob.AddOrUpdate(() => ExecuteWithCron(), cron);
			BackgroundJob.Schedule(() => ExecuteWithSchedule(), DateTimeOffset.FromUnixTimeSeconds(10));
		}
		
		public static void ExecuteWithCron()
		{
			Console.WriteLine("$Process with Cron { DateTime.Now}");
		}

		public static void ExecuteWithSchedule()
		{
			Console.WriteLine("$Process with Schedule { DateTime.Now}");
		}		
	}
}
