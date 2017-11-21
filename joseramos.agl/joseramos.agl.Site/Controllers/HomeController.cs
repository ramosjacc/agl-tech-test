using JoseRamos.Agl.Core.Models;
using JoseRamos.Agl.Core.Models.Enums;
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

            var filteredResult = _sortingProvider.SortAndFilter(result, Animal.Cat);
            return View(filteredResult);
        }
    }
}