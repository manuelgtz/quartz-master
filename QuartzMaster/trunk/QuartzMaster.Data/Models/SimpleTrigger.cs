using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;


namespace QuartzMaster.Data.Models
{
    [Serializable]
    public class SimpleTriggerInfo : BaseTrigger
    {
        [Display(ResourceType = typeof(Resources.QuartzMaster_Data),
            Name = "TriggerRepeatCount",
            ShortName = "TriggerRepeatCount",
            GroupName = "Trigger Repeat Count")]
        [Integer(ErrorMessageResourceType = typeof(Resources.QuartzMaster_Data_Errors),
            ErrorMessageResourceName = "NotIntegerError")]
        public int RepeatCount { get; set; }

        [Display(ResourceType = typeof(Resources.QuartzMaster_Data),
            Name = "TriggerRepeatInterval",
            ShortName = "TriggerRepeatInterval",
            GroupName = "Trigger Repeat Interval")]
        [Required(ErrorMessageResourceName = "RequiredError",
            ErrorMessageResourceType = typeof(Resources.QuartzMaster_Data_Errors))]
        [Integer(ErrorMessageResourceType = typeof(Resources.QuartzMaster_Data_Errors),
            ErrorMessageResourceName = "NotIntegerError")]        
        public TimeSpan RepeatInterval { get; set; }        
    }
}
