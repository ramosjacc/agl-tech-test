using JoseRamos.Agl.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace JoseRamos.Agl.Core.Services
{
    public class CacheProvider : ICacheProvider
    {
        public T GetOrSet<T>(string cacheKey, Func<T> getItemCallback) where T : class
        {
            T item = MemoryCache.Default.Get(cacheKey) as T;
            if (item == null)
            {
                item = getItemCallback();
                if(item != null) MemoryCache.Default.Add(cacheKey, item, DateTime.Now.AddMinutes(30));
            }
            return item;
        }
    }
}
