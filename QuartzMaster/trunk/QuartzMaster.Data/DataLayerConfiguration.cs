using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace QuartzMaster.Data
{
    #region Scheduler Instance Info Config. Elements

    public class SchedulerInstanceInfoElement : ConfigurationElement
    {

        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get
            {
                return this["name"] as string;
            }
        }


        [ConfigurationProperty("description", IsRequired = false)]
        public string Description
        {
            get
            {
                return this["description"] as string;
            }
        }

        [ConfigurationProperty("url", IsRequired = true)]
        public Uri Url
        {
            get
            {
                return this["url"] as Uri;
            }
        }
    }

    public class SchedulerInstanceInfoElementCollection : ConfigurationElementCollection
    {
        public SchedulerInstanceInfoElement this[int index]
        {
            get
            {
                return base.BaseGet(index) as SchedulerInstanceInfoElement;
            }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new SchedulerInstanceInfoElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SchedulerInstanceInfoElement)element).Name;
        }
    }

    #endregion


    public class DataLayerConfiguration : ConfigurationSection
    {
        public static DataLayerConfiguration Instance
        {
            get
            {
                return ConfigurationManager.GetSection("DataLayerConfiguration") as DataLayerConfiguration;                
            }
        }

        [ConfigurationProperty("refreshLatency",DefaultValue=1000,IsRequired=false)]
        public int RefreshLatency
        {
            get
            {
                return (int)this["refreshLatency"];
            }
        }

        [ConfigurationProperty("schedulerInstances", IsRequired=true)]
        public SchedulerInstanceInfoElementCollection SchedulerInstances
        {
            get
            {
                return this["schedulerInstances"] as SchedulerInstanceInfoElementCollection;
            }
        }        
    }
}
