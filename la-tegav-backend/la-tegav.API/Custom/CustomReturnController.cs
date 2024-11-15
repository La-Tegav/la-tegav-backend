using la_tegav.Application.Reponses;
using la_tegav.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace la_tegav.API.Custom;

public class CustomReturnController : ControllerBase
{
    [NonAction]
    protected ActionResult ResultHandler(Exception ex)
    {
        BaseReponse errorDetailModel = new BaseReponse();

        switch (ex)
        {
            case NullReferenceException:
                errorDetailModel.MessageDetail = ex.Message;
                errorDetailModel.Status = StatusCodes.Status404NotFound;
                return NotFound(errorDetailModel);
            case NotFoundException:
                errorDetailModel.MessageDetail = ex.Message;
                errorDetailModel.Status = StatusCodes.Status404NotFound;
                return NotFound(errorDetailModel);

            default:
                errorDetailModel.MessageDetail = ex.Message ?? string.Empty;
                errorDetailModel.Status = StatusCodes.Status500InternalServerError;
                return StatusCode(StatusCodes.Status500InternalServerError, errorDetailModel);
        }
    }
}
