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
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
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

        public async Task<UserDto?> GetByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PersonalNumber = user.PersonalNumber,
                Phone = user.Details?.Phone,
                Address = user.Details?.Address,
                DateOfBirth = user.Details?.DateOfBirth
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

            var created = await _userRepository.AddAsync(user);

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
        public async Task<bool> UpdateAsync(Guid id, CreateUserDto dto)
        {
            var existing = await _userRepository.GetByIdAsync(id);
            if (existing == null || existing.Details == null) return false;

            existing.FirstName = dto.FirstName;
            existing.LastName = dto.LastName;
            existing.PersonalNumber = dto.PersonalNumber;
            existing.Details.Phone = dto.Phone;
            existing.Details.Address = dto.Address;
            existing.Details.DateOfBirth = dto.DateOfBirth;

            return await _userRepository.UpdateAsync(existing);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _userRepository.DeleteAsync(id);
        }

        public async Task<string?> GetUserInitialsAsync(string identifier)
        {
            var user = await _userRepository.GetUserBySearchTerm(identifier);
            if (user is null) return null;

            return user.FirstName[0].ToString()+". "+ user.LastName[0].ToString() + ".";
        }
    }
}
