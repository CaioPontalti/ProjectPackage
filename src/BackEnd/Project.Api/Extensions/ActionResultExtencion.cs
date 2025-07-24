using Microsoft.AspNetCore.Mvc;
using Project.Application.Resources.Response;
using System.Net;

namespace Project.Api.Extensions
{
    public static class ActionResultExtencion
    {
        public static IActionResult ToActionResult<T>(this Result<T> result)
        {
            return result.StatusCode switch
            {
                HttpStatusCode.OK => new OkObjectResult(result),
                HttpStatusCode.Created => new CreatedResult(string.Empty, result),
                HttpStatusCode.NoContent => new NoContentResult(),
                HttpStatusCode.BadRequest => new BadRequestObjectResult(result),
                HttpStatusCode.Conflict => new ConflictObjectResult(result),
                HttpStatusCode.NotFound => new NotFoundObjectResult(result),
                _ => new ObjectResult("Erro inesperado") { StatusCode = (int)HttpStatusCode.InternalServerError }
            };
        }

        public static IActionResult ToActionResult(this Result result)
        {
            return result.StatusCode switch
            {
                HttpStatusCode.OK => new OkResult(),
                HttpStatusCode.Created => new StatusCodeResult((int)HttpStatusCode.Created),
                HttpStatusCode.NoContent => new NoContentResult(),
                HttpStatusCode.BadRequest => new BadRequestObjectResult(result),
                HttpStatusCode.Conflict => new ConflictObjectResult(result),
                HttpStatusCode.NotFound => new NotFoundObjectResult(result),
                _ => new ObjectResult("Erro inesperado") { StatusCode = (int)HttpStatusCode.InternalServerError }
            };
        }
    }
}