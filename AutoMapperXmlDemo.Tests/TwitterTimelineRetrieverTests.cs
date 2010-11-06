using System.Linq;
using System.Xml.Linq;
using AutoMapper;
using AutoMapperXmlDemo.Web.Application;
using AutoMapperXmlDemo.Web.Application.Domain;
using NUnit.Framework;

namespace AutoMapperXmlDemo.Tests
{
    [TestFixture]
    public class TwitterTimelineRetrieverTests
    {
        [Test]
        public void ShouldContainTweetXmlMapping()
        {
            // arrange
            var twitterTimelineRetriever = new TwitterTimelineRetriever();

            // act
            var map = Mapper.FindTypeMapFor<XElement, ITweetContract>();

            // assert
            Assert.NotNull(map);
        }

        [Test]
        public void ShouldContainAtLeastOneElement()
        {
            // arrange
            var twitterTimelineRetriever = new TwitterTimelineRetriever();

            // act
            var publicTimeline = twitterTimelineRetriever.GetPublicTimeline(1);

            // assert
            Assert.IsTrue(publicTimeline.Any());
        }

        [Test]
        public void ShouldReturnExactNumberOfElements()
        {
            // arrange
            var twitterTimelineRetriever = new TwitterTimelineRetriever();

            // act
            var publicTimeline = twitterTimelineRetriever.GetPublicTimeline(3);

            // assert
            Assert.AreEqual(publicTimeline.Count(), 3);
        }
    }
}
