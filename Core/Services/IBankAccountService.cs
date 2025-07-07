using InternetBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IBankAccountService
    {
        Task<IEnumerable<BankAccountDto>> GetAllAsync();
        Task<BankAccountDto?> GetByIdAsync(int id);
        Task<BankAccountDto> CreateAsync(CreateBankAccountDto dto);
        Task<bool> UpdateAsync(int id, CreateBankAccountDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
