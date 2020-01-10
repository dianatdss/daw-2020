using TheaterTicketsManagement.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TheaterTicketsManagement.Infrastructure
{
    public class AppUserStore : IUserStore<AppUser>, IUserPasswordStore<AppUser>
    {
        private  UserRepository _userRepository;
        public AppUserStore(UserRepository userRepository) {
            this._userRepository = userRepository;
        }
        public Task<IdentityResult> CreateAsync(AppUser user, CancellationToken cancellationToken)
        {
            this._userRepository.Users.Add(new AppUser
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                NormalizeUserName = user.NormalizeUserName,
                PasswordHash = user.PasswordHash,
                Role = "Admin"
            });

            this._userRepository.SaveChanges();

            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> DeleteAsync(AppUser user, CancellationToken cancellationToken)
        {
            var appUser = this._userRepository.Users.FirstOrDefault(
                u => u.Id == user.Id
                );
            if (appUser != null )
            {
                this._userRepository.Users.Remove(appUser);
            }
            return Task.FromResult(IdentityResult.Success);
        }

        public void Dispose()
        {
         //   throw new NotImplementedException();
        }

        public Task<AppUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            return Task.FromResult(this._userRepository.Users.FirstOrDefault(
                u => u.Id == userId));
        }

        public Task<AppUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return Task.FromResult(this._userRepository.Users.FirstOrDefault(
                u => u.NormalizeUserName == normalizedUserName));
        }

        public Task<string> GetNormalizedUserNameAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizeUserName);
        }

        public Task<string> GetPasswordHashAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<string> GetUserIdAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id);
        }

        public Task<string> GetUserNameAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }

        public Task<bool> HasPasswordAsync(AppUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash != null);
        }

        public Task SetNormalizedUserNameAsync(AppUser user, string normalizedName, CancellationToken cancellationToken)
        {
            user.NormalizeUserName = normalizedName;
            return Task.CompletedTask;
        }

        public Task SetPasswordHashAsync(AppUser user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(AppUser user, string userName, CancellationToken cancellationToken)
        {
            user.UserName = userName;
            return Task.CompletedTask;
        }

        public Task<IdentityResult> UpdateAsync(AppUser user, CancellationToken cancellationToken)
        {
            var appUser = this._userRepository.Users.FirstOrDefault(
                u => u.Id == user.Id);
            if (appUser != null )
            {
                appUser.NormalizeUserName = user.NormalizeUserName;
                appUser.UserName = user.UserName;
                appUser.Email = user.Email;
                appUser.PasswordHash = user.PasswordHash;
            }
            return Task.FromResult(IdentityResult.Success);
        }
    }
}
