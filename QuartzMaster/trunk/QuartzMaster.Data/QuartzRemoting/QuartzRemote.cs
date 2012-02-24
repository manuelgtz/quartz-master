using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Collections.Specialized;
using Quartz;
using Quartz.Impl;
using QuartzMaster.Data.Models;
using AutoMapper;

namespace QuartzMaster.Data.QuartzRemoting
{
    public class QuartzRemote
    {
        public IScheduler Scheduler { get;private set; }
        public string SchedulerName { get;private set; }
        public string SchedulerDescription { get; private set; }
        public Uri InstanceUrl { get; private set; }

        public QuartzRemote(string instanceName,Uri instanceUrl,string schedulerDescription = "")
        {
            NameValueCollection properties = new NameValueCollection();
            SchedulerName = instanceName;            
            
            properties["quartz.scheduler.proxy"] = "true";
            properties["quartz.scheduler.proxy.address"] = instanceUrl.ToString();
            InstanceUrl = instanceUrl;
            ISchedulerFactory sf = new StdSchedulerFactory(properties);
            Scheduler = sf.GetScheduler();
        }

        public IEnumerable<BaseTrigger> GetTriggetsOfJob(string jobName,string jobGroupName)
        {
            List<BaseTrigger> returnData = new List<BaseTrigger>();

            var triggers = Scheduler.GetTriggersOfJob(jobName, jobGroupName);

            foreach (Trigger trigger in triggers)
                returnData.Add(Mapper.Map<BaseTrigger>(trigger));

            return returnData;
        }

        public dynamic GetTriggerInfo(string triggerName,string triggerGroupName)
        {
            dynamic returnData = null;

            Trigger targetTrigger = Scheduler.GetTrigger(triggerName, triggerGroupName);
            if (targetTrigger is Quartz.SimpleTrigger)
                returnData = Mapper.Map<SimpleTriggerInfo>((Quartz.SimpleTrigger)targetTrigger);
            else if (targetTrigger is Quartz.CronTrigger)
                returnData = Mapper.Map<CronTriggerInfo>((Quartz.CronTrigger)targetTrigger);
            else returnData = Mapper.Map<BaseTrigger>(targetTrigger); 

            return returnData;
        }
        
        public IEnumerable<BaseTrigger> GetTriggers()
        {
            List<BaseTrigger> returnData = new List<BaseTrigger>();

            foreach (string triggerGroupName in Scheduler.TriggerGroupNames)
            {
                var triggerNames = Scheduler.GetTriggerNames(triggerGroupName);
                foreach(string triggerName in triggerNames)
                {
                    dynamic triggerInfo = GetTriggerInfo(triggerName, triggerGroupName);

                    BaseTrigger convertedTrigger = (BaseTrigger)triggerInfo;
                    if (convertedTrigger != null)
                        returnData.Add(convertedTrigger);
                }
            }

            return returnData;
        }
    }
}
