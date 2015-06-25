using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.ContentSearch.Linq;


namespace Sitecore.Base.Site.Controllers.Base
{


    public class JsonPageResult
    {
     
        public string Title { get; set; }
        public string Url { get; set; }

    }
    public class SearchAPIController : Controller
    {
        //
        // GET: /Custom/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search()
        {

            return Redirect("/Search?keyword=" + Request.Form["Keyword"]);
        }

        public JsonResult GetResults(string search)
        {

            var index = ContentSearchManager.GetIndex("sitecore_web_index");

            using (var context = index.CreateSearchContext())
            {
                var results = context.GetQueryable<SearchResultItem>()
                    .Where(x => x.TemplateName == "Page")
                    .Where(x=>x.Content.Contains(search))
                    .GetResults()
                    .Hits
                    .Select(x => x.Document);

                return Json(GetJsonPageResults(results), JsonRequestBehavior.AllowGet);

            }


        }

        private static List<JsonPageResult> GetJsonPageResults(IEnumerable<SearchResultItem> results)
        {
            return results.Select(result => new JsonPageResult() {Title = result.Name, Url = result.Url}).ToList();
        }
    }
}
