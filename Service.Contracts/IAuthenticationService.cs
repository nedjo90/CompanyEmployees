using Microsoft.AspNetCore.Identity;
using Shared.DataTransfertObjects;

namespace Service.Contracts;

public interface IAuthenticationService
{
    Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
}