using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace QuartzMaster.Data.Converters
{
    internal class CronExpressionConverter : ITypeConverter<Quartz.CronExpression,string>
    {
        public string Convert(ResolutionContext context)
        {
            return ((Quartz.CronExpression)context.SourceValue).CronExpressionString;
        }
    }
}
