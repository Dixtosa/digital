using Core.DBModel;
using InternetBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class LoanLimitRepository : ILoanLimitRepository
    {
        private readonly InternetBankDbContext loancontext;

        public LoanLimitRepository(InternetBankDbContext context)
        {
            loancontext = context;
        }

        public async Task<bool> CreateAsync(CreateLoanLimitDto dto)
        {
            var exists = await loancontext.Users.AnyAsync(u => u.Id == dto.UserId);
            if (!exists) return false;

            var limit = new LoanLimits
            {
                CreatedAt = DateTime.UtcNow,
                UserId = dto.UserId,
                Amount = dto.Amount
            };

            loancontext.LoanLimits.Add(limit);
            await loancontext.SaveChangesAsync();
            return true;
        }
    }

}
