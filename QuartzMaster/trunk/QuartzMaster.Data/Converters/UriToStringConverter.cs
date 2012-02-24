using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace QuartzMaster.Data.Converters
{
    internal class UriToStringConverter : ITypeConverter<System.Uri, string>
    {
        public string Convert(ResolutionContext context)
        {
            if (context.SourceValue == null)
            {
                return String.Empty;
            }

            return ((System.Uri)context.SourceValue).AbsoluteUri;
        }
    }
}
