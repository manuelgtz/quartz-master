using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace QuartzMaster.Data.Models
{
    public class JobDataItem
    {
        [Display(ResourceType=typeof(Resources.QuartzMaster_Data),
            Name="DataItemKey",
            ShortName = "DataItemKey")]
        public string Key { get; set; }
        
        [Display(ResourceType=typeof(Resources.QuartzMaster_Data),
            Name = "DataItemValue",
            ShortName = "DataItemValue")]
        public dynamic Value { get; set; }
    }
}
