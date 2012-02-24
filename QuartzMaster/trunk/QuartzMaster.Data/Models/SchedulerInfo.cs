using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;
using QuartzMaster.Data.Models;

namespace QuartzMaster.Data
{
    public class SchedulerInfo
    {      
        [StringLength(256,MinimumLength=2,
            ErrorMessageResourceName = "StringMinMaxLengthError",
            ErrorMessageResourceType = typeof(Resources.QuartzMaster_Data_Errors))]
        [Display(Name="SchedulerName",ResourceType=typeof(Resources.QuartzMaster_Data))]
        [Required(ErrorMessageResourceName = "RequiredError",
            ErrorMessageResourceType = typeof(Resources.QuartzMaster_Data_Errors))]
        public string SchedulerName { get; set; }

        //[StringLength(4096,
        //    ErrorMessageResourceName = "StringMaxLengthError",
        //    ErrorMessageResourceType = typeof(Resources.QuartzMaster_Data_Errors))]
        //[Display(Name = "SchedulerDescription", ResourceType = typeof(Resources.QuartzMaster_Data))]
        //public string SchedulerDescription { get; set; }

        [StringLength(2048,
            ErrorMessageResourceName = "StringMaxLengthError",
            ErrorMessageResourceType = typeof(Resources.QuartzMaster_Data_Errors))]
        [Required(ErrorMessageResourceName = "RequiredError",
            ErrorMessageResourceType = typeof(Resources.QuartzMaster_Data_Errors))]
        [Display(Name = "SchedulerInstanceName", ResourceType = typeof(Resources.QuartzMaster_Data))]
        public string SchedulerInstanceId { get; set; }

        [StringLength(4096,
            ErrorMessageResourceName = "StringMaxLengthError",
            ErrorMessageResourceType = typeof(Resources.QuartzMaster_Data_Errors))]
        [Display(Name = "SchedulerHostname", ResourceType = typeof(Resources.QuartzMaster_Data))]
        [DataType(DataType.Url)]
        [Url(ErrorMessageResourceType = typeof(Resources.QuartzMaster_Data_Errors),
            ErrorMessageResourceName="InvalidUrlError")]
        [Required(ErrorMessageResourceName = "RequiredError",
            ErrorMessageResourceType = typeof(Resources.QuartzMaster_Data_Errors))]
        public Uri InstanceUrl { get; set; }
    }
}
