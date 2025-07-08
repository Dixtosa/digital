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
        Task<UserDto?> GetByIdAsync(int id);
        Task<UserDto> CreateAsync(CreateUserDto dto);
        Task<bool> UpdateAsync(int id, CreateUserDto dto);
        Task<bool> DeleteAsync(int id);
        Task<string?> GetUserInitialsAsync(string identifier);

    }
}
