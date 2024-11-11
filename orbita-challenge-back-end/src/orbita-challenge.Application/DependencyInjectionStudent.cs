using Microsoft.Extensions.DependencyInjection;
using orbita_challenge.Application.AutoMapper;
using orbita_challenge.Application.UseCases.Students.Delete;
using orbita_challenge.Application.UseCases.Students.GetAll;
using orbita_challenge.Application.UseCases.Students.GetById;
using orbita_challenge.Application.UseCases.Students.Register;
using orbita_challenge.Application.UseCases.Students.Update;

namespace orbita_challenge.Application;
public static class DependencyInjectionStudent
{
    public static void AddAplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    public static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    public static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterStudentUseCase, RegisterStudentUseCase>();
        services.AddScoped<IGetAllStudentsUseCase, GetAllStudentsUseCase>();
        services.AddScoped<IGetStudentByIdUseCase, GetStudentByIdUseCase>();
        services.AddScoped<IDeleteStudentUseCase, DeleteStudentUseCase>();
        services.AddScoped<IUpdateStudentUseCase, UpdateStudentUseCase>();
    }
}
