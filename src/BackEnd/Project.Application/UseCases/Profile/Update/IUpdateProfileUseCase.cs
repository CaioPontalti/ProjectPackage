using Project.Application.Resources.Response;
using Project.Application.UseCases.Profile.Update.Request;

namespace Project.Application.UseCases.Profile.Update;

public interface IUpdateProfileUseCase
{
    Task<Result> ExecuteAsync(UpdateProfileRequest request);
}