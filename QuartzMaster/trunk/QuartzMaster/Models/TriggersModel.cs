using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Web;
using QuartzMaster.Data.Models;
using QuartzMaster.Data.QuartzRemoting;

namespace QuartzMaster.Models
{
    public class TriggersModel
    {
        public IEnumerable<SimpleTriggerInfo> SimpleTriggers { get; set; }
        public IEnumerable<CronTriggerInfo> CronTriggers { get; set; }

        public TriggersModel(string schedulerInstanceId)
        {
            var triggers = RemoteSchedulerRepository.Instance.Schedulers.
                            First(sched => sched.Scheduler.SchedulerInstanceId.Equals(schedulerInstanceId,StringComparison.OrdinalIgnoreCase)).GetTriggers();

            SimpleTriggers = triggers.Where(row => row != null).OfType<SimpleTriggerInfo>().ToArray();
            CronTriggers = triggers.Where(row => row != null).OfType<CronTriggerInfo>().ToArray();
        }
    }
}