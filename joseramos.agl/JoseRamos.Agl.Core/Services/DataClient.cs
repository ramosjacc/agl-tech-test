using JoseRamos.Agl.Core.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using JoseRamos.Agl.Core.Models;

namespace JoseRamos.Agl.Core.Services
{
    public class DataClient: RestClient, IDataClient
    {
        private readonly ICacheProvider _cacheProvider;

        public DataClient(ICacheProvider cacheProvider)
        {
            _cacheProvider = cacheProvider;
            BaseUrl = new Uri(ConfigurationManager.AppSettings["baseUrl"]);
        }

        public List<Person> GetPetOwnerListing()
        {
            return _cacheProvider.GetOrSet<List<Person>>("pet_listing", () => {
                RestRequest request = new RestRequest(ConfigurationManager.AppSettings["jsonApi"], Method.GET);
                var response = Execute<List<Person>>(request);
                return response.Data;
            });
        }


    }
}
