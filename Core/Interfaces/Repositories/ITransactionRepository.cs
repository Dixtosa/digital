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
        Task<List<Transactions>> GetByUserIdsAndDateRangeAsync(Guid userId, DateTime from, DateTime to);
        Task<List<Transactions>> GetByAccountIdsAndDateRangeAsync(Guid accountId, DateTime from, DateTime to);
    }
}
