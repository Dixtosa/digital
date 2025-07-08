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
        private readonly ICardRepository _cardRepository;
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly List<string> _defaultCurrencyCodes = new() { "GEL", "USD", "EUR" };
        private readonly Guid _defaultAccountType = Guid.Empty;


        public CardService(ICardRepository cardRepository, IBankAccountRepository bankAccountRepository)
        {
            _cardRepository = cardRepository;
            _bankAccountRepository = bankAccountRepository;
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

            var createdCard = await _cardRepository.AddAsync(card);
            var currencyMap = new Dictionary<string, Guid>
            {
                { "GEL", Guid.NewGuid() }, //todo:
                { "USD", Guid.NewGuid() },
                { "EUR", Guid.NewGuid() }
            };

            var accounts = _defaultCurrencyCodes.Select(code => new BankAccount
            {
                CreatedAt = DateTime.UtcNow,
                AccountNumber = Guid.NewGuid().ToString("N").Substring(0, 16),
                AccountTypeId = _defaultAccountType, 
                Amount = 0,
                CurrencyId = currencyMap[code],
                UserId = dto.UserId,
                CardId = createdCard.Id
            });

            await _bankAccountRepository.AddMultipleAsync(accounts);

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
            var cards = await _cardRepository.GetAllAsync();
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

        public async Task<CardDto?> GetByIdAsync(Guid id)
        {
            var card = await _cardRepository.GetByIdAsync(id);
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

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _cardRepository.DeleteAsync(id);
        }
    }
}
