using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;
using QuartzMaster.Data.Models;
using QuartzMaster.Data.QuartzRemoting;

namespace QuartzMaster.Models
{
    public class DashboardModel
    {
        public QuartzMaster.Data.SchedulerInfo SchedulerInfo { get; set; }

        public IEnumerable<BaseTrigger> Triggers { get; set; }
        

        public DashboardModel(string schedulerId)
        {
            SchedulerInfo = RemoteSchedulerRepository.Instance.SchedulersInfo.First(sched => sched.SchedulerInstanceId.Equals(schedulerId, StringComparison.OrdinalIgnoreCase));
            Triggers = RemoteSchedulerRepository.Instance.Schedulers.
                            First(sched => sched.Scheduler.SchedulerInstanceId.Equals(schedulerId, StringComparison.OrdinalIgnoreCase)).GetTriggers();
        }
    }
}