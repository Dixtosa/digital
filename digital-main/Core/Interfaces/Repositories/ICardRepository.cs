using Core.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface ICardRepository
    {
        Task<Card> AddAsync(Card card);
        Task<IEnumerable<Card>> GetAllAsync();
        Task<Card?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}
