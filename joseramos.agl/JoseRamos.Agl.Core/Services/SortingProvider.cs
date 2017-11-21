using JoseRamos.Agl.Core.Models;
using JoseRamos.Agl.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseRamos.Agl.Core.Services
{
    public class SortingProvider : ISortingProvider
    {
        public List<OwnerSortResult> SortAndFilter(List<Person> list, Animal type)
        {
            var group = list.GroupBy(p => p.Gender);

            var results = group.Select(c => new OwnerSortResult { Gender = c.Key,
                                                               PetNames = c.Where(x => x.Pets != null)
                                                                 .SelectMany(p => p.Pets)
                                                                 .Where(d => d.Type.ToLower() == type.ToString().ToLower())
                                                                 .OrderBy(o => o.Name)
                                                                 .Select(e => e.Name).ToList(),
                                                               AnimalType  = type}).ToList();

            return results;
        }
    }
}
