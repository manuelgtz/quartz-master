using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace QuartzMaster.Data.Converters
{
    internal class StringToCronExpressionConverter : ITypeConverter<string,Quartz.CronExpression>
    {
        public Quartz.CronExpression Convert(ResolutionContext context)
        {
            return new Quartz.CronExpression(context.SourceValue.ToString());
        }
    }
}
