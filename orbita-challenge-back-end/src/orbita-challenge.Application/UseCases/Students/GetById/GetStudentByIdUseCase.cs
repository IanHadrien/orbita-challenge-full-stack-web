using AutoMapper;
using orbita_challenge.Communication.Responses;
using orbita_challenge.Domain.Repositories.Students;

namespace orbita_challenge.Application.UseCases.Students.GetById;
public class GetStudentByIdUseCase : IGetStudentByIdUseCase
{
    private readonly IStudentsReadOnlyRepository _repository; 
    private readonly IMapper _mapper;

    public GetStudentByIdUseCase(IStudentsReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseOneStudentJson> Execute(long id)
    {
        var result = await _repository.GetById(id);

        if (result is null)
        {
            throw new System.Exception("Aulo não encontrado");
        }

        return _mapper.Map<ResponseOneStudentJson>(result);
    }
}
