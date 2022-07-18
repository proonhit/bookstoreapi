using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;
using BookStore.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(BookStoreDbContext context) : base(context) { }

        public override async Task<List<User>> GetAll()
        {
            return await Db.Users
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<User> GetUser(string userName, string password)
        {
            return await Db.Users.AsNoTracking()
                .Where(u => u.Username.Equals(userName) && u.Password.Equals(password) && u.IsActive == true)
                .FirstOrDefaultAsync();
        }
    }
}
