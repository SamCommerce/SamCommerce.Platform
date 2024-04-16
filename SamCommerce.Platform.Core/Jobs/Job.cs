using SamCommerce.Platform.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Core.Jobs
{
    public class Job : Entity
    {
        public string State { get; set; }
        public bool Completed { get; set; }
    }
}
