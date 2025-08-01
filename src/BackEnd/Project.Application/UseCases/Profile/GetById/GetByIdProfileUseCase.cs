using Project.Application.Resources.Response;
using Project.Application.UseCases.Profile.GetById.Response;
using Project.Domain.Interfaces.Repositories;
using System.Net;

namespace Project.Application.UseCases.Profile.GetById;

public class GetByIdProfileUseCase : IGetByIdProfileUseCase
{
    private readonly IProfileRepository _profileRepository;

    public GetByIdProfileUseCase(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }

    public async Task<Result<GetByIdProfileResponse>> ExecuteAsync(string accountId)
    {
        if (string.IsNullOrEmpty(accountId))
            return Result<GetByIdProfileResponse>.Failure(HttpStatusCode.BadRequest, "");

        var profile = await _profileRepository.GetByAccountId(accountId);
        if (profile is null)
            return Result<GetByIdProfileResponse>.Failure(HttpStatusCode.NotFound, "");

        return Result<GetByIdProfileResponse>.Success(HttpStatusCode.OK, new GetByIdProfileResponse(profile));
    }
}
