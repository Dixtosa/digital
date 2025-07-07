using Core.DBModel;
using Core.Interfaces.Repositories;
using Core.Services;
using Core.Services;
using InternetBank.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository icardRepository;
        private readonly IBankAccountRepository ibankAccountRepository;
        private readonly List<string> idefaultCurrencyCodes = new() { "GEL", "USD", "EUR" };

        public CardService(ICardRepository cardRepository, IBankAccountRepository bankAccountRepository)
        {
            icardRepository = cardRepository;
            ibankAccountRepository = bankAccountRepository;
        }

        public async Task<CardDto> CreateAsync(CreateCardDto dto)
        {
            var card = new Card
            {
                CreatedAt = DateTime.UtcNow,
                UserId = dto.UserId,
                NameOnCard = dto.NameOnCard,
                CardNumber = dto.CardNumber,
                ValidThru = dto.ValidThru,
                CVV = dto.CVV
            };

            var createdCard = await icardRepository.AddAsync(card);
            var currencyMap = new Dictionary<string, int>
            {
                { "GEL", 1 },
                { "USD", 2 },
                { "EUR", 3 }
            };

            var accounts = idefaultCurrencyCodes.Select(code => new BankAccount
            {
                CreatedAt = DateTime.UtcNow,
                AccountNumber = Guid.NewGuid().ToString("N").Substring(0, 16),
                AccountTypeId = 1, 
                Amount = 0,
                CurrencyId = currencyMap[code],
                UserId = dto.UserId,
                CardId = createdCard.Id
            });

            await ibankAccountRepository.AddMultipleAsync(accounts);

            return new CardDto
            {
                Id = createdCard.Id,
                UserId = createdCard.UserId,
                NameOnCard = createdCard.NameOnCard,
                CardNumber = createdCard.CardNumber,
                ValidThru = createdCard.ValidThru,
                CVV = createdCard.CVV
            };
        }

        public async Task<IEnumerable<CardDto>> GetAllAsync()
        {
            var cards = await icardRepository.GetAllAsync();
            return cards.Select(c => new CardDto
            {
                Id = c.Id,
                UserId = c.UserId,
                NameOnCard = c.NameOnCard,
                CardNumber = c.CardNumber,
                ValidThru = c.ValidThru,
                CVV = c.CVV
            });
        }

        public async Task<CardDto?> GetByIdAsync(int id)
        {
            var card = await icardRepository.GetByIdAsync(id);
            if (card == null) return null;

            return new CardDto
            {
                Id = card.Id,
                UserId = card.UserId,
                NameOnCard = card.NameOnCard,
                CardNumber = card.CardNumber,
                ValidThru = card.ValidThru,
                CVV = card.CVV
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await icardRepository.DeleteAsync(id);
        }
    }
}
