using InternetBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ICardService
    {
        Task<CardDto> CreateAsync(CreateCardDto dto);
        Task<IEnumerable<CardDto>> GetAllAsync();
        Task<CardDto?> GetByIdAsync(Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}
