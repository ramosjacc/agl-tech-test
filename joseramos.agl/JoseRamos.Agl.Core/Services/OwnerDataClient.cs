using JoseRamos.Agl.Core.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace JoseRamos.Agl.Core.Services
{

    public class OwnerDataClient: RestClient, IDataClient
    {
        private readonly ICacheProvider _cacheProvider;
        public override Uri BaseUrl { get => base.BaseUrl; set => base.BaseUrl = value; }

        public OwnerDataClient(ICacheProvider cacheProvider)
        {
            _cacheProvider = cacheProvider;
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
