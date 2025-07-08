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
            List<Guid> accountIds, DateTime from, DateTime to)
        {
            return await trancontext.Transactions
                .Include(t => t.SenderAccountId)
                .Include(t => t.ReceiverAccountId)
                .Where(t =>
                    (accountIds.Contains(t.SenderAccountId) || accountIds.Contains(t.ReceiverAccountId)) &&
                    t.Date >= from && t.Date <= to)
                .ToListAsync();
        }
    }
}

