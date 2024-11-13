using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using orbita_challenge.Domain.Repositories;
using orbita_challenge.Domain.Repositories.Students;
using orbita_challenge.Domain.Repositories.Users;
using orbita_challenge.Domain.Security.Cryptography;
using orbita_challenge.Domain.Security.Tokens;
using orbita_challenge.Infrastructure.DataAccess;
using orbita_challenge.Infrastructure.DataAccess.Repositories;
using orbita_challenge.Infrastructure.Security.Tokens;

namespace orbita_challenge.Infrastructure;
public static class DependencyInjectionStudent
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddToken(services, configuration);
        AddRepositories(services);

        services.AddScoped<IPasswordEncripter, Security.Cryptography.BCrypt>();
    }

    private static void AddToken(IServiceCollection services, IConfiguration configuration)
    {
        var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinutes");
        var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

        services.AddScoped<IAccessTokenGenerator>(config => new JwtTokenGenerator(expirationTimeMinutes, signingKey!));
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
