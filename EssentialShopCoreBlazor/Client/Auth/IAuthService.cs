using EssentialShopCoreBlazor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EssentialShopCoreBlazor.Client.Auth
{
    interface IAuthService
    {
        Task<UserLogInResult> Login(LoginModel loginModel);
        Task Logout();
        Task<RegistrationResult> Register(ApplicationUserModel registerModel);
    }
}
