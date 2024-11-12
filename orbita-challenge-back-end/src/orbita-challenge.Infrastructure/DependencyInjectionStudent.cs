using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using orbita_challenge.Domain.Repositories;
using orbita_challenge.Domain.Repositories.Students;
using orbita_challenge.Domain.Repositories.Users;
using orbita_challenge.Domain.Security.Cryptography;
using orbita_challenge.Infrastructure.DataAccess;
using orbita_challenge.Infrastructure.DataAccess.Repositories;

namespace orbita_challenge.Infrastructure;
public static class DependencyInjectionStudent
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);

        services.AddScoped<IPasswordEncripter, Security.BCrypt>();
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IStudentsReadOnlyRepository, StudentsRepository>();
        services.AddScoped<IStudentsWriteOnlyRepository, StudentsRepository>();
        services.AddScoped<IStudentUpdateOnlyRepository, StudentsRepository>();
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");

        var version = new Version(8, 0, 35);
        var serverVersion = new MySqlServerVersion(version);

        services.AddDbContext<OrbitaChallengeDbContext>(config => config.UseMySql(connectionString, serverVersion));
    }
}
