using Hangfire;
using System;

namespace HangFire.Services
{
	public class Process
	{
		private const string cron = "*/5 * * * * *";

		public static void Start()
		{
			RecurringJob.AddOrUpdate(() => Console.Write($"Alpha Process: {DateTime.Now}"), cron);
			RecurringJob.AddOrUpdate(() => Console.Write($"Beta Process: {DateTime.Now}"), cron);
		}
	}
}
