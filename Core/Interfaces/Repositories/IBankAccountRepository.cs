using Core.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IBankAccountRepository
    {
        Task<IEnumerable<BankAccount>> GetAllAsync();
        Task<BankAccount?> GetByIdAsync(Guid id);
        Task<BankAccount> AddAsync(BankAccount account);
        Task AddMultipleAsync(IEnumerable<BankAccount> accounts);
        Task<bool> UpdateAsync(BankAccount account);
        Task<bool> DeleteAsync(Guid id);
    }
}
