using JoseRamos.Agl.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoseRamos.Agl.Core.Models
{
    public class OwnerSortResult
    {
        public string Gender { get; set; }
        public List<string> PetNames { get; set; }
        public Animal AnimalType { get; set; }

    }
}
