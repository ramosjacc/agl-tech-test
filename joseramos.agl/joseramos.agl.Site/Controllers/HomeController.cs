using JoseRamos.Agl.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JoseRamos.Agl.Site.Controllers
{

    public class HomeController : AsyncController
    {
        private readonly IDataClient _dataClient;
        private readonly ISortingProvider _sortingProvider;

        public HomeController(ISortingProvider sortingProvider, IDataClient dataClient)
        {
            _dataClient = dataClient;
            _sortingProvider = sortingProvider;
        }
        public ActionResult Index()     
        {
            var result = _dataClient.GetPetOwnerListing();
            return View(result);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}