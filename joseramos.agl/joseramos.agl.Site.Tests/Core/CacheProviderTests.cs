using JoseRamos.Agl.Core.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace joseramos.agl.Site.Tests.Core
{
    [TestFixture]
    public class CacheProviderTests
    {
        private readonly string cacheKey = "test_key";
        [Test]
        public void Does_Item_Get_Cached()
        {
            CacheProvider provider = new CacheProvider();
            var item = MemoryCache.Default.Get(cacheKey);

            Assert.IsNull(item);

            provider.GetOrSet<string>(cacheKey, () => { return "test_value"; });
            item = MemoryCache.Default.Get(cacheKey);

            Assert.IsNotNull(item, $"Item value: {item}");
        }
    }
}
