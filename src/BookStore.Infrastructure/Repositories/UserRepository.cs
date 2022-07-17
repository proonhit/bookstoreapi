using BookStore.Domain.Interfaces;
using BookStore.Domain.Models;
using BookStore.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    }
}
