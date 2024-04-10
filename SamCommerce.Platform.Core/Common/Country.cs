using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Core.Common
{
    public class Country
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IList<CountryRegion> Regions { get; set; }
    }
}
