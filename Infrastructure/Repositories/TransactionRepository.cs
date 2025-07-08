using InternetBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core;
using Core.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly InternetBankDbContext  trancontext;

        public TransactionRepository(InternetBankDbContext context)
        {
            trancontext = context;
        }

        public async Task<List<Core.DBModel.Transactions>> GetByAccountIdsAndDateRangeAsync(
            Guid accountId, DateTime from, DateTime to)
        {
            return await trancontext.Transactions
                .Include(t => t.SenderAccountId)
                .Include(t => t.ReceiverAccountId)
                .Where(t =>
                    (t.SenderAccountId == accountId) &&
                    t.Date >= from && t.Date <= to)
                .ToListAsync();
        }

        public async Task<List<Core.DBModel.Transactions>> GetByUserIdsAndDateRangeAsync(
            Guid userId, DateTime from, DateTime to)
        {
            return await trancontext.Transactions
                .Include(t => t.SenderAccountId)
                .Include(t => t.ReceiverAccountId)
                .Where(t =>
                    (t.SenderAccount.UserId == userId) &&
                    t.Date >= from && t.Date <= to)
                .ToListAsync();
        }
    }
}

