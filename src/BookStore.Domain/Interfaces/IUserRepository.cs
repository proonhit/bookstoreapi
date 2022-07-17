using BookStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        new Task<List<User>> GetAll();
    }
}
