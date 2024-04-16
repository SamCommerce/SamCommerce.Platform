using SamCommerce.Platform.Core.GenericCrud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Core.DynamicProperties
{
    public interface IDynamicPropertySearchService : ISearchService<DynamicPropertySearchCriteria, DynamicPropertySearchResult, DynamicProperty>
    {
        [Obsolete("Use SearchAsync()", DiagnosticId = "VC0005", UrlFormat = "https://docs.virtocommerce.org/products/products-virto3-versions/")]
        Task<DynamicPropertySearchResult> SearchDynamicPropertiesAsync(DynamicPropertySearchCriteria criteria);
    }
}
