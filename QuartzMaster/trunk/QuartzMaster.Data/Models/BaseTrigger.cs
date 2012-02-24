using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace QuartzMaster.Data.Models
{
    [Serializable]
    public class BaseTrigger
    {
        /* shared trigger properties */

        [Display(ResourceType = typeof(Resources.QuartzMaster_Data),
            Name = "TriggerName",
            ShortName = "TriggerName",
            GroupName = "Trigger Information")]
        [Required(ErrorMessageResourceName = "RequiredError",
            ErrorMessageResourceType = typeof(Resources.QuartzMaster_Data_Errors))]
        [StringLength(512, MinimumLength = 2,
            ErrorMessageResourceName = "StringMinMaxLengthError",
            ErrorMessageResourceType = typeof(Resources.QuartzMaster_Data_Errors))]
        public string FullName { get; set; }

        [Display(ResourceType = typeof(Resources.QuartzMaster_Data),
            Name = "TriggerGroup",
            ShortName = "TriggerGroup",
            GroupName = "Trigger Information")]
        [Required(ErrorMessageResourceName = "RequiredError",
            ErrorMessageResourceType = typeof(Resources.QuartzMaster_Data_Errors))]
        [StringLength(1024, MinimumLength = 2,
            ErrorMessageResourceName = "StringMinMaxLengthError",
            ErrorMessageResourceType = typeof(Resources.QuartzMaster_Data_Errors))]
        public string Group { get; set; }

        [Display(ResourceType = typeof(Resources.QuartzMaster_Data),
            Name = "TriggerDescription",
            ShortName = "TriggerDescription",
            GroupName = "Trigger Information")]
        [StringLength(4096,
            ErrorMessageResourceName = "StringMaxLengthError",
            ErrorMessageResourceType = typeof(Resources.QuartzMaster_Data_Errors))]
        public string Description { get; set; }

        [Display(ResourceType = typeof(Resources.QuartzMaster_Data),
            Name = "TriggerStartDate",
            ShortName = "TriggerStartDate",
            GroupName = "Trigger Information")]
        [Required(ErrorMessageResourceName = "RequiredError",
            ErrorMessageResourceType = typeof(Resources.QuartzMaster_Data_Errors))]
        [DataType(DataType.DateTime)]
        public DateTime StartTimeUtc { get; set; }

        [Display(ResourceType = typeof(Resources.QuartzMaster_Data),
            Name = "TriggerEndDate",
            ShortName = "TriggerEndDate",
            GroupName = "Trigger Information")]
        [DataType(DataType.DateTime)]
        public DateTime? EndTimeUtc { get; set; }

        [Display(ResourceType = typeof(Resources.QuartzMaster_Data),
            Name = "TriggerNextFireTime",
            ShortName = "TriggerNextFireTime",
            GroupName = "Trigger Information")]
        [DataType(DataType.DateTime)]
        [Editable(false)]
        public DateTime? NextFireTimeUtc { get; set; }

        [Display(ResourceType = typeof(Resources.QuartzMaster_Data),
            Name = "TriggerCalendarName",
            ShortName = "TriggerCalendarName",
            GroupName = "Trigger Information")]
        public string CalendarName { get; set; }

        [Display(ResourceType = typeof(Resources.QuartzMaster_Data),
            Name = "TriggerFinalFireTime",
            ShortName = "TriggerFinalFireTime",
            GroupName = "Trigger Information")]
        [Editable(false)]
        [DataType(DataType.DateTime)]
        [ScaffoldColumn(false)]
        public DateTime? FinalFireTimeUtc { get; set; }

        [Display(ResourceType = typeof(Resources.QuartzMaster_Data),
            Name = "TriggerIsVolatile",
            ShortName = "TriggerIsVolatile",
            GroupName = "Trigger Information")]
        public bool Volatile { get; set; }

    }
}
