using JoseRamos.Agl.Core.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

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


    }
}
