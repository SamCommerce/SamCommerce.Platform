using SamCommerce.Platform.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Core.DynamicProperties
{
    public class DynamicPropertyName : ValueObject
    {
        /// <summary>
        /// Language ID, e.g. en-US.
        /// </summary>
        public string Locale { get; set; }
        public string Name { get; set; }

    }
}
