using JoseRamos.Agl.Core.Interfaces;
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
        private readonly ISortingProvider _ownerInfoService;

        public HomeController(ISortingProvider ownerInfoService)
        {
            _ownerInfoService = ownerInfoService;
        }
        public ActionResult Index()
        {
            return View();
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