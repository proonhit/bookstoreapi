using BookStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void Dispose()
        {
            _userRepository?.Dispose();
        }
    }
}
