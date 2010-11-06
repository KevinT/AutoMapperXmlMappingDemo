using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using AutoMapper;
using AutoMapperXmlDemo.Web.Application.Domain;
using AutoMapperXmlDemo.Web.Application.Maps;

namespace AutoMapperXmlDemo.Web.Application
{
    public class TwitterTimelineRetriever
    {
        private readonly XDocument _twitterTimelineXml;

        public TwitterTimelineRetriever()
        {
            MapInitializer.CreateTweetXmlMap();

            try
            {
                _twitterTimelineXml = XDocument.Load("http://api.twitter.com/1/statuses/public_timeline.xml");
            }
            catch(System.Net.WebException webException)
            {
                throw new WebException("Unable to load Twitter Public Timeline");
            }
        }

        public IEnumerable<ITweetContract> GetPublicTimeline(int numberOfTweets)
        {
            var tweets = _twitterTimelineXml.Descendants("status")
                .Take(numberOfTweets);

            return tweets.Select(Mapper.Map<XElement, ITweetContract>).ToList();
        }
    }
}