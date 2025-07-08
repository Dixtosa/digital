using Infrastructure.Repositories;
using InternetBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Services;
using Core.Interfaces.Repositories;
using AutoMapper;


namespace Infrastructure.Services
{ 
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly BankAccountRepository accountRepository;
        private readonly IMapper mapper;

        public TransactionService(
            ITransactionRepository transactionRepository,
            BankAccountRepository accountRepository,
            IMapper mapper)
        {
            this.transactionRepository = transactionRepository;
            accountRepository = accountRepository;
            this.mapper = mapper;
        }

        public async Task<TransactionReportDto> GetTransactionReportAsync(TransactionReportDto request)
        {
            List<Core.DBModel.Transactions> transactions;

            if (request.FromAccountId.HasValue)
            {
                var accounts = await accountRepository.GetByUserIdAsync(request.FromAccountId.Value);
                var accountIds = accounts.Select(a =>
                {
                    return a.Id;
                }).ToList();

                transactions = await transactionRepository.GetByAccountIdsAndDateRangeAsync(
                    accountIds, request.FromAccountId, request.ToAccountId);
            }
            else if (request.FromAccountId.HasValue)
            {
                transactions = await transactionRepository.GetByAccountIdsAndDateRangeAsync(
                    new List<Guid> { request.FromAccountId.Value }, request.FromAccountId, request.ToAccountId);
            }
            else
            {
                throw new ArgumentException("Either UserId or AccountId must be provided.");
            }

            var income = transactions
                .Where(t => request.FromAccountId != null && t.ReceiverAccountId == request.ToAccountId)
                         //|| (request.FromAccountId != null && t.ReceiverAccountId?.FromAccountId == request.FromAccountId))
                .Sum(t => t.Amount);

            var outcome = transactions
                .Where(t => request.FromAccountId != null && t.SenderAccountId == request.FromAccountId)
                         //|| request.FromAccountId != null && t.SenderAccountId?.FromAccountId == request.FromAccountId)
                .Sum(t => t.Amount);

            return new TransactionReportDto
            {
                Transactions = mapper.Map<List<TransactionDto>>(transactions),
                TotalIncome = income,
                TotalOutcome = outcome
            };
        }

        //public Task<TransactionReportDto> GetTransactionReportAsync(TransactionReportDto request)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
