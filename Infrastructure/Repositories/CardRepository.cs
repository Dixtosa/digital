using Core.DBModel;
using Core.Interfaces.Repositories;
using InternetBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly InternetBankDbContext _dbContext;

        public CardRepository(InternetBankDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Card> AddAsync(Card card)
        {
            _dbContext.Cards.Add(card);
            await _dbContext.SaveChangesAsync();
            return card;
        }

        public async Task<IEnumerable<Card>> GetAllAsync()
        {
            return await _dbContext.Cards.ToListAsync();
        }

        public async Task<Card?> GetByIdAsync(int id)
        {
            return await _dbContext.Cards.FindAsync(id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var card = await _dbContext.Cards.FindAsync(id);
            if (card == null) return false;

            _dbContext.Cards.Remove(card);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

