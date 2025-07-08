using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DBModel;

namespace Core.Interfaces.Repositories
{
    public interface ITransactionRepository
    {
        Task<List<Transactions>> GetByAccountIdsAndDateRangeAsync(List<Guid> accountIds, DateTime from, DateTime to);
        Task<List<Transactions>> GetByAccountIdsAndDateRangeAsync(List<Guid> guids, Guid? fromAccountId, Guid? toAccountId);
    }
}
