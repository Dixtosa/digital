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
            this.accountRepository = accountRepository;
            this.mapper = mapper;
        }

        public async Task<TransactionReportResponseDto> GetTransactionReportAsync(TransactionReportRequestDto request)
        {
            List<Core.DBModel.Transactions> transactions;

            if (request.UserId.HasValue)
            {
                transactions = await transactionRepository.GetByUserIdsAndDateRangeAsync(
                    request.UserId.Value, request.FromDate, request.ToDate);
            }
            else if (request.AccountId.HasValue)
            {
                transactions = await transactionRepository.GetByAccountIdsAndDateRangeAsync(
                    request.AccountId.Value, request.FromDate, request.ToDate);
            }
            else
            {
                throw new ArgumentException("Either UserId or AccountId must be provided.");
            }

            var income = transactions
                .Where(t => request.UserId != null && t.ReceiverAccountId == request.AccountId)
                         //|| (request.FromAccountId != null && t.ReceiverAccountId?.FromAccountId == request.FromAccountId))
                .Sum(t => t.Amount);

            var outcome = transactions
                .Where(t => request.UserId != null && t.SenderAccountId == request.UserId)
                         //|| request.FromAccountId != null && t.SenderAccountId?.FromAccountId == request.FromAccountId)
                .Sum(t => t.Amount);

            return new TransactionReportResponseDto
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
