﻿using BookStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<IEnumerable<User>> GetAll();
<<<<<<< HEAD
        Task<string> GetUser(string userName, string password);
        Task<bool> Register(User user);

=======
>>>>>>> parent of f1661e9 (login)
    }
}
