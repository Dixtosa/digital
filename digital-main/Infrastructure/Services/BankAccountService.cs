using Core.DBModel;
using Core.Interfaces.Repositories;
using InternetBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Services;


namespace Infrastructure.Services
{
    public class BankAccountService : IBankAccountService
    {
        private readonly IBankAccountRepository _accountRepository;

        public BankAccountService(IBankAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<IEnumerable<BankAccountDto>> GetAllAsync()
        {
            var accounts = await _accountRepository.GetAllAsync();
            return accounts.Select(a => new BankAccountDto
            {
                Id = a.Id,
                AccountNumber = a.AccountNumber,
                AccountTypeId = a.AccountTypeId,
                Amount = a.Amount,
                CurrencyId = a.CurrencyId,
                UserId = a.UserId
            });
        }

        public async Task<BankAccountDto?> GetByIdAsync(int id)
        {
            var account = await _accountRepository.GetByIdAsync(id);
            if (account == null) return null;

            return new BankAccountDto
            {
                Id = account.Id,
                AccountNumber = account.AccountNumber,
                AccountTypeId = account.AccountTypeId,
                Amount = account.Amount,
                CurrencyId = account.CurrencyId,
                UserId = account.UserId
            };
        }

        public async Task<BankAccountDto> CreateAsync(CreateBankAccountDto dto)
        {
            var account = new BankAccount
            {
                CreatedAt = DateTime.UtcNow,
                AccountNumber = dto.AccountNumber,
                AccountTypeId = dto.AccountTypeId,
                Amount = dto.Amount,
                CurrencyId = dto.CurrencyId,
                UserId = dto.UserId
            };

            var created = await _accountRepository.AddAsync(account);

            return new BankAccountDto
            {
                Id = created.Id,
                AccountNumber = created.AccountNumber,
                AccountTypeId = created.AccountTypeId,
                Amount = created.Amount,
                CurrencyId = created.CurrencyId,
                UserId = created.UserId
            };
        }

        public async Task<bool> UpdateAsync(int id, CreateBankAccountDto dto)
        {
            var account = await _accountRepository.GetByIdAsync(id);
            if (account == null) return false;

            account.AccountNumber = dto.AccountNumber;
            account.AccountTypeId = dto.AccountTypeId;
            account.Amount = dto.Amount;
            account.CurrencyId = dto.CurrencyId;
            account.UserId = dto.UserId;

            return await _accountRepository.UpdateAsync(account);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _accountRepository.DeleteAsync(id);
        }
    }
}

