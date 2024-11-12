using Microsoft.EntityFrameworkCore;
using orbita_challenge.Domain.Entities;

namespace orbita_challenge.Infrastructure.DataAccess;
internal class OrbitaChallengeDbContext : DbContext
{
    public OrbitaChallengeDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Student> Students { get; set; }
    public DbSet<User> Users { get; set; }
}
