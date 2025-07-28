using Project.Application.Resources.Messages.User;
using Project.Application.Resources.Response;
using Project.Application.UseCases.User.Create.Request;
using Project.Application.UseCases.User.Create.Response;
using Project.Domain.Interfaces.Repositories;
using System.Net;

namespace Project.Application.UseCases.User.Create
{
    public class CreateUserUseCase : ICreateUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public CreateUserUseCase(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public async Task<Result<CreateUserResponse>> ExecuteAsync(CreateUserRequest request)
        {
            request.Validate();

            if (request.HasNotification())
                return Result<CreateUserResponse>.Failure(HttpStatusCode.BadRequest, request.Notifications.ToArray());

            var userDb = await _userRepository.GetByEmailAsync(request.Email);
            if(userDb is not null)
                return Result<CreateUserResponse>.Failure(HttpStatusCode.Conflict, UserMessageValidation.UserExists);

            var user = Domain.Entities.v1.User.Create(request.Email, request.Name, request.Password, request.Role);

            await _userRepository.CreateAsync(user);

            return Result<CreateUserResponse>
                .Success(HttpStatusCode.Created, new CreateUserResponse(user.Id.ToString()));
        }
    }
}