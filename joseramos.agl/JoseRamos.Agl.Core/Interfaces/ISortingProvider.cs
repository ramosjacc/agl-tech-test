using JoseRamos.Agl.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseRamos.Agl.Core.Models
{
    public interface ISortingProvider
    {
        List<Person> SortAndFilter();
    }
}
