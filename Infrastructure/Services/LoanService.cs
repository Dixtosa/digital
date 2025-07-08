using Core.DBModel;
using Core.Services;
using InternetBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace Infrastructure.Services
{
    public class LoanService : ILoanService
    {
        private readonly InternetBankDbContext loanscontext;

        public LoanService(InternetBankDbContext context)
        {
            loanscontext = context;
        }

        public async Task<(bool Success, string Message)> ProcessDuePaymentsAsync()
        {
            var dueLoans = await loanscontext.Loans
                .Include(l => l.BankAccount)
                .Where(l => l.LoanDate <= DateTime.Today && l.LoanRemainigAmount > 0)
                .ToListAsync();

            int processed = 0;

            foreach (var loan in dueLoans)
            {
                var mainAccount = loan.BankAccount;
                decimal required = loan.MonthlyPaymentAmount;
                decimal collected = 0;

                var deductions = new List<(BankAccount account, decimal amount)>();

                var firstPortion = Math.Min(required, mainAccount.Amount);
                if (firstPortion > 0)
                {
                    collected += firstPortion;
                    mainAccount.Amount -= firstPortion;
                    deductions.Add((mainAccount, firstPortion));
                }

                if (collected < required)
                {
                    var otherAccounts = await loanscontext.BankAccounts
                        .Where(a => a.UserId == loan.UserId && a.Id != mainAccount.Id && a.Amount > 0)
                        .OrderByDescending(a => a.Amount)
                        .ToListAsync();

                    foreach (var acc in otherAccounts)
                    {
                        var portion = Math.Min(required - collected, acc.Amount);
                        if (portion > 0)
                        {
                            collected += portion;
                            acc.Amount -= portion;
                            deductions.Add((acc, portion));
                        }

                        if (collected >= required)
                            break;
                    }
                }

                if (collected < required)
                    continue;

                loan.LoanRemainigAmount -= required;
                loan.LoanDate = loan.LoanDate.AddMonths(1);

                var transaction = new Transactions
                {
                    Date = DateTime.UtcNow,
                    SenderAccountId = default, //todo: wtf is dis
                    ReceiverAccountId = (Guid)loan.BankAccountId,
                    ReceiverAccount = loan.BankAccount.AccountNumber,
                    Amount = required,
                    CurrencyId = loan.BankAccount.CurrencyId,
                    Description = "ავტომატური სესხის გადახდა"
                };

                loanscontext.Transactions.Add(transaction);
                processed++;
            }

            await loanscontext.SaveChangesAsync();
            return (true, $"დამუშავდა {processed} აქტიური სესხი");
        }
    }

}