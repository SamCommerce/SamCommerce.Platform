using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Core.Common
{
    public class GenericSearchResult<T>
    {
        public GenericSearchResult()
        {
            Results = new List<T>();
        }
        public int TotalCount { get; set; }
        public IList<T> Results { get; set; }
    }
}
