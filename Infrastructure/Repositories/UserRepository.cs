using Core.DBModel;
using InternetBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly InternetBankDbContext userContext;

        public UserRepository(InternetBankDbContext dbContext)
        {
            userContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await userContext.Users.Include(u => u.Details).ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await userContext.Users.Include(u => u.Details).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> AddAsync(User user)
        {
            userContext.Users.Add(user);
            await userContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UpdateAsync(User user)
        {
            if (!userContext.Users.Any(u => u.Id == user.Id)) return false;
            userContext.Users.Update(user);
            await userContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await userContext.Users.Include(u => u.Details).FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) return false;
            userContext.Users.Remove(user);
            await userContext.SaveChangesAsync();
            return true;
        }

        public async Task<string?> GetUserInitialsAsync(string identifier)
        {
            var user = await userContext.Users
                .Include(u => u.Details)
                .FirstOrDefaultAsync(u =>
                    u.PersonalNumber == identifier ||
                    u.Details.Phone == identifier ||
                    userContext.BankAccounts.Any(b => b.AccountNumber == identifier && b.UserId == u.Id));

            if (user == null) return null;

            return $"{user.FirstName} {user.LastName}";
        }
    }
}
