using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using QuartzMaster.Data.Converters;
using QuartzMaster.Data.Models;

namespace QuartzMaster.Data.QuartzRemoting
{
    public class RemoteSchedulerRepository
    {
        public IEnumerable<QuartzRemote> Schedulers { get; private set; }

        private static RemoteSchedulerRepository instance;

        public static RemoteSchedulerRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RemoteSchedulerRepository();
                }

                return instance;
            }

        }

        private void CreateMappings()
        {
            Mapper.CreateMap<System.Uri, string>().ConvertUsing<UriToStringConverter>();
            Mapper.CreateMap<Quartz.CronExpression, string>().ConvertUsing<CronExpressionConverter>();
            Mapper.CreateMap<string, Quartz.CronExpression>().ConvertUsing<StringToCronExpressionConverter>();
            
            Mapper.CreateMap<Quartz.Trigger,BaseTrigger>().
                 ForMember(cti => cti.NextFireTimeUtc,
                          m => m.MapFrom<DateTime?>(ct => ct.GetNextFireTimeUtc()));

            Mapper.CreateMap<Quartz.SimpleTrigger, SimpleTriggerInfo>().
                 ForMember(cti => cti.NextFireTimeUtc,
                          m => m.MapFrom<DateTime?>(ct => ct.GetNextFireTimeUtc()));
            
            Mapper.CreateMap<Quartz.CronTrigger, CronTriggerInfo>().
                             ForMember(cti => cti.NextFireTimeUtc,
                                      m => m.MapFrom<DateTime?>(ct => ct.GetNextFireTimeUtc()));

            Mapper.CreateMap<QuartzRemote, SchedulerInfo>().
                ForMember(qr => qr.SchedulerInstanceId,
                          m => m.MapFrom<string>(si => si.Scheduler.SchedulerInstanceId));
        }

        private RemoteSchedulerRepository()
        {
            if (DataLayerConfiguration.Instance == null)
            {
                return;
            }

            CreateMappings();
            List<QuartzRemote> remoteSchedulers = new List<QuartzRemote>();

            foreach (SchedulerInstanceInfoElement schedulerInfo in DataLayerConfiguration.Instance.SchedulerInstances)
            {
                QuartzRemote remoteScheduler = new QuartzRemote(schedulerInfo.Name, schedulerInfo.Url);
                remoteSchedulers.Add(remoteScheduler);
            }
            
            Schedulers = remoteSchedulers.ToArray();
        }

        public IEnumerable<SchedulerInfo> SchedulersInfo
        {
            get
            {
                List<SchedulerInfo> schedulerInfos = new List<SchedulerInfo>();
                lock (Schedulers)
                {
                    foreach (QuartzRemote schedulerRemote in Schedulers)
                    {
                        
                        schedulerInfos.Add(Mapper.Map<SchedulerInfo>(schedulerRemote));
                    }
                }

                return schedulerInfos;
            }
        }
    }
}
