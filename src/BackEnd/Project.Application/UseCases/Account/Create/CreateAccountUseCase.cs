using Project.Application.Resources.Messages.Account;
using Project.Application.Resources.Response;
using Project.Application.UseCases.Account.Create.Request;
using Project.Application.UseCases.Account.Create.Response;
using Project.Domain.Interfaces.Repositories;
using System.Net;

namespace Project.Application.UseCases.Account.Create
{
    public class CreateAccountUseCase : ICreateAccountUseCase
    {
        private readonly IAccountRepository _userRepository;

        public CreateAccountUseCase(IAccountRepository accountRepository) 
        {
            _userRepository = accountRepository;
        }

        public async Task<Result<CreateAccountResponse>> ExecuteAsync(CreateAccountRequest request)
        {
            request.Validate();

            if (request.HasNotification())
                return Result<CreateAccountResponse>.Failure(HttpStatusCode.BadRequest, request.Notifications.ToArray());

            var userDb = await _userRepository.GetByEmailAsync(request.Email);
            if(userDb is not null)
                return Result<CreateAccountResponse>.Failure(HttpStatusCode.Conflict, AccountMessageValidation.AccountExists);

            var user = Domain.Entities.v1.Account.Create(request.Email, request.Password, request.Role, request.AccountType);

            await _userRepository.CreateAsync(user);

            return Result<CreateAccountResponse>
                .Success(HttpStatusCode.Created, new CreateAccountResponse(user.Id.ToString()));
        }
    }
}