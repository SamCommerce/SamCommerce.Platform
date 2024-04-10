using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Core.ChangeUtils
{
    /// <summary>
    /// Allows to mark public properties to use with <see cref="ChangeDetector"/>.
    /// </summary>
    public sealed class DetectChangesAttribute : Attribute
    {
        public string ChangeKey { get; private set; }
        public DetectChangesAttribute(string changeKey)
        {
            ChangeKey = changeKey;
        }
    }
}
