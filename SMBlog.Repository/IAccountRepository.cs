using Microsoft.AspNetCore.Identity;
using SMBlog.Models.Account;

namespace SMBlog.Repository
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> CreateAsync(ApplicationUserIdentity user, 
            CancellationToken cancellationToken);
        public Task<ApplicationUserIdentity> GetByUsernameAsync(string normalizedUsername, 
            CancellationToken cancellationToken);
    }
}