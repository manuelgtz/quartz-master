using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using QuartzMaster.Data.QuartzRemoting;
using Quartz;
using Quartz.Job;
using Quartz.Impl;
using System.Collections.Specialized;
using System.IO;
using System.Diagnostics;

namespace QuartzMaster.Tests
{
    /// <summary>
    /// The tests in this context are to make sure the data is transfered from remote scheduler properly
    /// </summary>
    [Subject("Assuming test remote scheduler is running")]
    public class when_QuartzRemote_is_instantiated : ICleanupAfterEveryContextInAssembly
    {
        static QuartzRemote quartzRemote;
        static Process testSchedulerHostProcess;
        Establish context =
        () =>
        {
            string testSchedulerHost = typeof(TestServerHost.ExecutableLocationPlaceholder).Assembly.Location;
            testSchedulerHostProcess = System.Diagnostics.Process.Start(testSchedulerHost);
        };

        Because of = () => { quartzRemote = new QuartzRemote("RemoteServerTestScheduler",
            new Uri("tcp://localhost:500/QuartzScheduler")); };

        It should_return_an_instance_of_remote_scheduler = () =>
        {
            testSchedulerHostProcess.ShouldNotBeNull();
            quartzRemote.Scheduler.ShouldNotBeNull();
        };

        It should_return_two_jobs_with_correct_names = () =>
        {
            var jobs = quartzRemote.Scheduler.GetJobNames("default");
            jobs.ShouldContain("localJob", "localJob 2");
        };

        It should_return_proper_data_map_from_a_job = () =>
        {
            var jobDetail = quartzRemote.Scheduler.GetJobDetail("localJob", "default");
            jobDetail.JobDataMap.Keys.ShouldContain("msg","msg 2","msg 3");
            jobDetail.JobDataMap["msg"].ShouldEqual("Some message!");
            jobDetail.JobDataMap["msg 2"].ShouldEqual("Some message 2!");
            jobDetail.JobDataMap["msg 3"].ShouldEqual("Some message 3!");
        };

        public void AfterContextCleanup()
        {
            testSchedulerHostProcess.Kill();           
        }
    }
}
