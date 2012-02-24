using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace QuartzMaster.Data.Models
{
    [Serializable]
    public class CronTriggerInfo : BaseTrigger
    {
        [Display(ResourceType = typeof(Resources.QuartzMaster_Data),
            Name = "TriggerCronString",
            ShortName = "TriggerCronString",
            GroupName = "Trigger Information")]
        [Required(ErrorMessageResourceName = "RequiredError",
            ErrorMessageResourceType = typeof(Resources.QuartzMaster_Data_Errors))]
        [StringLength(24, MinimumLength = 6,
            ErrorMessageResourceName = "StringMinMaxLengthError",
            ErrorMessageResourceType = typeof(Resources.QuartzMaster_Data_Errors))]
        [RegularExpression(@"([^\s]+)\s([^\s]+)\s([^\s]+)\s([^\s]+)\s([^\s]+)\s([^#\n$]*)(\s#\s([^\n$]*)|$)",
            ErrorMessageResourceType=typeof(Resources.QuartzMaster_Data_Errors),
            ErrorMessageResourceName="InvalidCronError")]
        public string CronExpressionString { get; set; }

    }
}
