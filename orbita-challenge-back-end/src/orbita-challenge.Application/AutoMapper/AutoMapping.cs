using AutoMapper;
using orbita_challenge.Communication.Requests;
using orbita_challenge.Communication.Responses;
using orbita_challenge.Domain.Entities;

namespace orbita_challenge.Application.AutoMapper;
public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }
    private void RequestToEntity()
    {
        CreateMap<RequestRegisterStundetJson, Student>();

        CreateMap<RequestUpdateStudentJson, Student>()
        .ForMember(dest => dest.Ra, opt => opt.Ignore())
        .ForMember(dest => dest.Cpf, opt => opt.Ignore());
    }
    private void EntityToResponse()
    {
        CreateMap<Student, ResponseRegisteredStudentJson>();
        CreateMap<Student, ResponseOneStudentJson>();
    }
}
