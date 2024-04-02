using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Core.Swagger
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class SwaggerSchemaIdAttribute : Attribute
    {
        public string Id { get; private set; }

        public SwaggerSchemaIdAttribute(string id)
        {
            Id = id;
        }
    }
}
