using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using orbita_challenge.Infrastructure.DataAccess;

namespace orbita_challenge.Infrastructure.Migrations;
public static class DataBaseMigration
{
    public async static Task MigrateDatabase(IServiceProvider serviceProvider)
    {
        var dbContext = serviceProvider.GetRequiredService<OrbitaChallengeDbContext>();

        await dbContext.Database.MigrateAsync();
    }
}
