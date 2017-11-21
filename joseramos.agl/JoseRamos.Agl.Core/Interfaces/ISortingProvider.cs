using JoseRamos.Agl.Core.Models.Enums;
using System.Collections.Generic;

namespace JoseRamos.Agl.Core.Models
{
    public interface ISortingProvider
    {
        List<OwnerSortResult> SortAndFilter(List<Person> list, Animal type);
    }
}
