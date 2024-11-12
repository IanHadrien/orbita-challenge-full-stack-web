using Microsoft.AspNetCore.Mvc.Filters;

namespace orbita_challenge_api.Filters;
public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {

    }

    private void HandleProjectException(ExceptionContext context)
    {

    }

    private void ThrowUnkowError(ExceptionContext context)
    {
        //var errorResponse = new ResponseErrorJson
    }
}
