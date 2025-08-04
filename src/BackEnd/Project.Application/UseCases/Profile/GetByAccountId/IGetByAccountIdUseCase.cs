using Project.Application.Resources.Response;
using Project.Application.UseCases.Profile.GetById.Response;

namespace Project.Application.UseCases.Profile.GetById;

public interface IGetByAccountIdUseCase
{
    Task<Result<GetByAccountIdResponse>> ExecuteAsync(string accountId);
}