using Project.Application.Resources.Messages.Profile;
using Project.Application.Resources.Response;
using Project.Application.UseCases.Profile.GetById.Response;
using Project.Domain.Interfaces.Repositories;
using System.Net;

namespace Project.Application.UseCases.Profile.GetById;

public class GetByAccountIdUseCase : IGetByAccountIdUseCase
{
    private readonly IProfileRepository _profileRepository;

    public GetByAccountIdUseCase(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }

    public async Task<Result<GetByAccountIdResponse>> ExecuteAsync(string accountId)
    {
        if (string.IsNullOrEmpty(accountId))
            return Result<GetByAccountIdResponse>.Failure(HttpStatusCode.BadRequest, ProfileMessageValidation.AccountIdRequerid);

        var profile = await _profileRepository.GetByAccountIdAsync(accountId);
        if (profile is null)
            return Result<GetByAccountIdResponse>.Failure(HttpStatusCode.NotFound, ProfileMessageValidation.AccountNotFound);

        return Result<GetByAccountIdResponse>.Success(HttpStatusCode.OK, new GetByAccountIdResponse(profile));
    }
}