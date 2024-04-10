using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.Platform.Core.ChangeLog
{
    public interface IChangeLogService
    {
        Task SaveChangesAsync(params OperationLog[] operationLogs);
        Task<OperationLog[]> GetByIdsAsync(string[] ids);
        Task DeleteAsync(string[] ids);
    }
}