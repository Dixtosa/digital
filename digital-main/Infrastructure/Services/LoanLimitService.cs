using Core.Interfaces.Repositories;
using Core.Services;
using InternetBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class LoanLimitService : ILoanLimitService
    {
        private readonly ILoanLimitRepository loanrepository;

        public LoanLimitService(ILoanLimitRepository repository)
        {
            loanrepository = repository;
        }

        public async Task<bool> CreateLimitAsync(CreateLoanLimitDto dto)
        {
            return await loanrepository.CreateAsync(dto);
        }
    }
}
