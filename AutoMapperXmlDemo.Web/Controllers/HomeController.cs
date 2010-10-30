using System.Web.Mvc;
using AutoMapperXmlDemo.Web.Application;

namespace AutoMapperXmlDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        private TwitterTimelineRetriever _twitterTimelineRetriever; 
        public ActionResult Index()
        {
            _twitterTimelineRetriever = new TwitterTimelineRetriever();

            ViewModel.Message = "Twitter Public Timeline";

            return View(_twitterTimelineRetriever.GetPublicTimeline(10));
        }
    }
}
