using System.Linq;
using System.Xml.Linq;
using AutoMapper;
using AutoMapperXmlDemo.Web.Application.Domain;

namespace AutoMapperXmlDemo.Web.Application.Maps
{
    public class MapInitializer
    {
        public static void CreateTweetXmlMap()
        {
            Mapper.CreateMap<XElement, ITweetContract>()
                .ForMember(
                    dest => dest.Id,
                    options => options.ResolveUsing<XElementResolver<ulong>>()
                        .FromMember(source => source.Element("id")))
                .ForMember(
                    dest => dest.Name,
                    options => options.ResolveUsing<XElementResolver<string>>()
                        .FromMember(source => source.Element("user")
                            .Descendants("name").Single()))
                .ForMember(
                    dest => dest.UserName,
                    options => options.ResolveUsing<XElementResolver<string>>()
                        .FromMember(source => source.Element("user")
                            .Descendants("screen_name").Single()))
                .ForMember(
                    dest => dest.Body,
                    options => options.ResolveUsing<XElementResolver<string>>()
                        .FromMember(source => source.Element("text")))
                .ForMember(
                    dest => dest.ProfileImageUrl,
                    options => options.ResolveUsing<XElementResolver<string>>()
                        .FromMember(source => source.Element("user")
                            .Descendants("profile_image_url").Single()))
                .ForMember(
                    dest => dest.Created,
                    options => options.ResolveUsing<XElementResolver<string>>()
                        .FromMember(source => source.Element("created_at")));
        }
    }
}