using JoseRamos.Agl.Core.Models;
using JoseRamos.Agl.Core.Models.Enums;
using System;
using System.Web.Mvc;

namespace JoseRamos.Agl.Site.Controllers
{

    public class HomeController : Controller
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
            try
            {
                var result = _dataClient.GetPetOwnerListing();

                var filteredResult = _sortingProvider.SortAndFilter(result, Animal.Cat);

                //Normally you would use a separate viewmodel 
                return View(filteredResult);
            }
            catch (Exception e)
            {
                //log to diagnostics
                System.Diagnostics.Trace.TraceError(e.Message);
                throw;
            }
        }
    }
}