using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Api.Extensions;
using Project.Application.Resources.Response;
using Project.Application.UseCases.Account.GetAll;
using Project.Application.UseCases.Account.GetAll.Response;
using Project.Application.UseCases.Profile.GetById;

namespace Project.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {

        //[Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(Result<GetAllAccountsResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByAccountsAsync(
            [FromServices] IGetByIdProfileUseCase useCaseGetByAccountId,
            [FromQuery] string accountId)
        {
            var result = await useCaseGetByAccountId.ExecuteAsync(accountId);

            return result.ToActionResult();
        }
    }
}
