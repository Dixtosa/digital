using Core.Interfaces.Repositories;
using InternetBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(Guid id);
        Task<UserDto> CreateAsync(CreateUserDto dto);
        Task<bool> UpdateAsync(Guid id, CreateUserDto dto);
        Task<bool> DeleteAsync(Guid id);
        Task<string?> GetUserInitialsAsync(string identifier);

    }
}
