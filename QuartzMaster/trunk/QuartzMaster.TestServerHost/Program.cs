using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using Quartz.Impl;
using Quartz;
using Quartz.Job;


namespace QuartzMaster.TestServerHost
{
    class Program : IDisposable
    {
        private static IScheduler scheduler;

        static void Main(string[] args)
        {
            Console.WriteLine("Starting scheduler...");

            var properties = new NameValueCollection();
            properties["quartz.scheduler.instanceName"] = "RemoteServerTestScheduler";

            // set thread pool infoD:\Projects\QuartzMaster\QuartzMaster.TestServerHost\Program.cs
            properties["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz";
            properties["quartz.threadPool.threadCount"] = "5";
            properties["quartz.threadPool.threadPriority"] = "Normal";

            // set remoting expoter
            properties["quartz.scheduler.exporter.type"] = "Quartz.Simpl.RemotingSchedulerExporter, Quartz";
            properties["quartz.scheduler.exporter.port"] = "500";
            properties["quartz.scheduler.exporter.bindName"] = "QuartzScheduler";
            properties["quartz.scheduler.exporter.channelType"] = "tcp";

            var schedulerFactory = new StdSchedulerFactory(properties);
            scheduler = schedulerFactory.GetScheduler();

            // define the job and ask it to run
            var map = new JobDataMap();
            map.Put("msg", "Some message!");
            map.Put("msg 2", "Some message 2!");
            map.Put("msg 3", "Some message 3!");

            var job = new JobDetail("localJob", "default", typeof(NoOpJob))
            {
                JobDataMap = map
            };

            var job2 = new JobDetail("localJob 2", "default", typeof(NoOpJob))
            {
                JobDataMap = map
            };

            var trigger2 = new SimpleTrigger("Simple Trigger", "default", "localJob 2", "default", DateTime.Now, DateTime.Now.AddMinutes(10), SimpleTrigger.RepeatIndefinitely, new TimeSpan(0, 0, 45));

            var trigger = new CronTrigger("remotelyAddedTrigger", "default", "localJob", "default", DateTime.UtcNow, null, "/5 * * ? * *");

            var trigger3 = new SimpleTrigger("remotelyAddedTriggerB", "default", "localJob", "default", DateTime.Now, DateTime.Now.AddMinutes(10), SimpleTrigger.RepeatIndefinitely, new TimeSpan(0, 0, 45));

            // schedule the job
            scheduler.ScheduleJob(job, trigger3);
            scheduler.ScheduleJob(job2, trigger2);

            scheduler.Start();

            Console.WriteLine("Scheduler has been started.");
            Console.WriteLine("Press any key to stop scheduler");
            Console.ReadKey();
            scheduler.Shutdown();
        }

        public void Dispose()
        {
            scheduler.Shutdown();
        }
    }
}
