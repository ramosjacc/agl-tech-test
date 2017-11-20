using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseRamos.Agl.Core.Models
{
    public interface ICacheProvider
    {
        T GetOrSet<T>(string cacheKey, Func<T> getItemCallback) where T : class;

    }
}
