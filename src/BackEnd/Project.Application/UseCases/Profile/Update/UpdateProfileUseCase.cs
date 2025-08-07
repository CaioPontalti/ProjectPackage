using Project.Application.Resources.Messages.Profile;
using Project.Application.Resources.Response;
using Project.Application.UseCases.Profile.Update.Request;
using Project.Domain.Interfaces.Repositories;
using System.Net;

namespace Project.Application.UseCases.Profile.Update;

public class UpdateProfileUseCase : IUpdateProfileUseCase
{
    private readonly IProfileRepository _profileRepository;

    public UpdateProfileUseCase(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }

    public async Task<Result> ExecuteAsync(UpdateProfileRequest request)
    {
        request.Validate();

        if (request.HasNotification())
            return Result.Failure(HttpStatusCode.BadRequest, request.Notifications.ToArray());

        var profileDb = await _profileRepository.GetByIdAsync(request.Id);
        if (profileDb is null)
            return Result.Failure(HttpStatusCode.NotFound, ProfileMessageValidation.ProfileNotFound);

        profileDb.Update(request.Name, request.BirthDate, request.CellPhone, request.Address);

        await _profileRepository.UpdateAsync(profileDb);

        return Result.Success(HttpStatusCode.OK);
    }
}