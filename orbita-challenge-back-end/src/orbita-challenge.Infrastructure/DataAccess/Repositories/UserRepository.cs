using Microsoft.EntityFrameworkCore;
using orbita_challenge.Domain.Repositories.Users;

namespace orbita_challenge.Infrastructure.DataAccess.Repositories;
internal class UserRepository : IUserReadOnlyRepository
{
    private readonly OrbitaChallengeDbContext _dbContext;

    public UserRepository(OrbitaChallengeDbContext dbContext) => _dbContext = dbContext;

    public async Task<bool> ExistActiveUserWithEmail(string email)
    {
        return await _dbContext.Users.AnyAsync(user => user.Email.Equals(email));
    }
}
