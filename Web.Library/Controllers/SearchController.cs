using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SqlServer;
using Web.Library.Models;
using Web.Library.BusinessLayer.Search;
using Web.Library.BusinessLayer.Custom;
namespace Web.Library.Controllers
{
    public class SearchController : Controller
    {
        //
        // GET: /Search/

        private readonly TestService _dataService = new TestService();
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(Search model, string returnUrl)
        {
         

                var query = new Query(new Criteria {Term = model.SearchTerm}, _dataService);
                var data = new JsonNetResult
                               {
                                   Data = new {error = false, data = query.JsonAsset()},
                                   JsonRequestBehavior = JsonRequestBehavior.AllowGet
                               };
                ViewData["jsondata"] = data;
                return data;
            

            // return data;
            //return PartialView( Json(query.JsonAsset(), JsonRequestBehavior.AllowGet));
         
        }


        [HttpPost]
        public ActionResult Result(Search model, string returnUrl)
        {


            var query = new Query(new Criteria { Term = model.SearchTerm }, _dataService);
            var data = new JsonNetResult
            {
                Data = new { error = false, data = query.JsonAsset() },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
           // ViewBag["jsondata"] = data;
            return data;


            // return data;
            //return PartialView( Json(query.JsonAsset(), JsonRequestBehavior.AllowGet));

        }
    }
}
