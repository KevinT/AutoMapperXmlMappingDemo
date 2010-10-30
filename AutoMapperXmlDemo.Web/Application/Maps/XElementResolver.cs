using System;
using System.Xml.Linq;
using AutoMapper;

namespace AutoMapperXmlDemo.Web.Application.Maps
{
    public class XElementResolver<T> : ValueResolver<XElement, T>
    {
        protected override T ResolveCore(XElement source)
        {
            if (source == null || string.IsNullOrEmpty(source.Value))
                return default(T);

            return (T)Convert.ChangeType(source.Value, typeof(T));
        }
    }
}