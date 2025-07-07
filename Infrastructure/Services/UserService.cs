using Core.DBModel;
using Core.Interfaces.Repositories;
using Core.Services;
using Infrastructure.Repositories;
using InternetBank.Models;
using InternetBank.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository iuserRepository;

        public UserService(IUserRepository userRepository)
        {
            iuserRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await iuserRepository.GetAllAsync();
            return users.Select(u => new UserDto
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                PersonalNumber = u.PersonalNumber,
                Phone = u.Details?.Phone,
                Address = u.Details?.Address,
                DateOfBirth = u.Details?.DateOfBirth
            });
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await iuserRepository.GetByIdAsync(id);
            if (user == null || user.Details == null) return null;

            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PersonalNumber = user.PersonalNumber,
                Phone = user.Details.Phone,
                Address = user.Details.Address,
                DateOfBirth = user.Details.DateOfBirth
            };
        }

        public async Task<UserDto> CreateAsync(CreateUserDto dto)
        {
            var user = new User
            {
                CreatedAt = DateTime.UtcNow,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PersonalNumber = dto.PersonalNumber,
                Details = new UserDetails
                {
                    Address = dto.Address,
                    Phone = dto.Phone,
                    DateOfBirth = dto.DateOfBirth
                }
            };

            var created = await iuserRepository.AddAsync(user);

            return new UserDto
            {
                Id = created.Id,
                FirstName = created.FirstName,
                LastName = created.LastName,
                PersonalNumber = created.PersonalNumber,
                Phone = created.Details?.Phone,
                Address = created.Details?.Address,
                DateOfBirth = created.Details?.DateOfBirth
            };
        }
        public async Task<bool> UpdateAsync(int id, CreateUserDto dto)
        {
            var existing = await iuserRepository.GetByIdAsync(id);
            if (existing == null || existing.Details == null) return false;

            existing.FirstName = dto.FirstName;
            existing.LastName = dto.LastName;
            existing.PersonalNumber = dto.PersonalNumber;
            existing.Details.Phone = dto.Phone;
            existing.Details.Address = dto.Address;
            existing.Details.DateOfBirth = dto.DateOfBirth;

            return await iuserRepository.UpdateAsync(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await iuserRepository.DeleteAsync(id);
        }

        public async Task<string?> GetUserInitialsAsync(string identifier)
        {
            return await iuserRepository.GetUserInitialsAsync(identifier);
        }
    }
}
