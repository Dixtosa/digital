using Core.DBModel;
using Core.Interfaces.Repositories;
using InternetBank.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly InternetBankDbContext accountdbContext;

        public BankAccountRepository(InternetBankDbContext dbContext)
        {
            accountdbContext = dbContext;
        }

        public async Task<IEnumerable<BankAccount>> GetAllAsync()
        {
            return await accountdbContext.BankAccounts.ToListAsync();
        }

        public async Task<BankAccount?> GetByIdAsync(int id)
        {
            return await accountdbContext.BankAccounts.FindAsync(id);
        }

        public async Task<BankAccount> AddAsync(BankAccount account)
        {
            accountdbContext.BankAccounts.Add(account);
            await accountdbContext.SaveChangesAsync();
            return account;
        }

        public async Task AddMultipleAsync(IEnumerable<BankAccount> accounts)
        {
            accountdbContext.BankAccounts.AddRange(accounts);
            await accountdbContext.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(BankAccount account)
        {
            if (!accountdbContext.BankAccounts.Any(a => a.Id == account.Id))
                return false;

            accountdbContext.BankAccounts.Update(account);
            await accountdbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var account = await accountdbContext.BankAccounts.FindAsync(id);
            if (account == null)
                return false;

            accountdbContext.BankAccounts.Remove(account);
            await accountdbContext.SaveChangesAsync();
            return true;
        }
    }
}