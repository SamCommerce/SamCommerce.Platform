using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Core.Domain
{
    public interface IHasLanguage
    {
        string LanguageCode { get; }
    }
}
