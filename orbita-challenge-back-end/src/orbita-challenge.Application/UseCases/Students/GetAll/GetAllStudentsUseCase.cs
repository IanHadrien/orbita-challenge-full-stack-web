using AutoMapper;
using orbita_challenge.Communication.Responses;
using orbita_challenge.Domain.Repositories.Students;

namespace orbita_challenge.Application.UseCases.Students.GetAll;
public class GetAllStudentsUseCase : IGetAllStudentsUseCase
{
    private readonly IStudentsReadOnlyRepository _repository;
    private readonly IMapper _mapper;

    public GetAllStudentsUseCase(IStudentsReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseStudentsJson> Execute()
    {
        var result = await _repository.GetAll();

        return new ResponseStudentsJson
        {
            Students = _mapper.Map<List<ResponseOneStudentJson>>(result)
        };
    }
}
