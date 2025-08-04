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
        private readonly IAccountRepository _accountRepository;
        private readonly IProfileRepository _profileRepository;

        public CreateAccountUseCase(IAccountRepository accountRepository, IProfileRepository profileRepository) 
        {
            _accountRepository = accountRepository;
            _profileRepository = profileRepository;
        }

        public async Task<Result<CreateAccountResponse>> ExecuteAsync(CreateAccountRequest request)
        {
            request.Validate();

            if (request.HasNotification())
                return Result<CreateAccountResponse>.Failure(HttpStatusCode.BadRequest, request.Notifications.ToArray());

            var accountDb = await _accountRepository.GetByEmailAsync(request.Email);
            if(accountDb is not null)
                return Result<CreateAccountResponse>.Failure(HttpStatusCode.Conflict, AccountMessageValidation.AccountExists);

            var account = Domain.Entities.v1.Account.Create(request.Email, request.Password, request.Role, request.AccountType);

            await _accountRepository.CreateAsync(account);

            var profile = Domain.Entities.v1.Profile.Create(account.Id.ToString(), null, null, null);

            await _profileRepository.CreateAsync(profile);

            return Result<CreateAccountResponse>
                .Success(HttpStatusCode.Created, new CreateAccountResponse(account.Id.ToString()));
        }
    }
}