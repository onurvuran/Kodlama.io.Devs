using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserRepository _userRepository;
        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task UserEmailCanNotBeDuplicatedWhenInserted(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user != null) throw new BusinessException("Entered email already registered.");
        }

        public static void UserShouldBeExistWhenLoggedIn(User? user)
        {
            if (user == null) throw new BusinessException("Requested user does not exist.");
        }

        public static void UserCredentialsShouldBeMatchWhenLoggedIn(User user, string password)
        {
            bool isUserPasswordNotVerified = !HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);
            if (isUserPasswordNotVerified) throw new BusinessException("User credentials does not match.");
        }
    }
}
