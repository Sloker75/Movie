using DLL.Context;
using DLL.Models;
using DLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthorizationService
    {
        LoginDataRepository LoginDataRepository;
        public AuthorizationService(LoginDataRepository loginDataRepository)
        {
            this.LoginDataRepository = loginDataRepository;
        }

        public async Task<LoginData> AuthorizationAsync(LoginData login)
        {
            return (await LoginDataRepository.FindByConditionAsync(x => x.Login == login.Login && x.Password == login.Password))?.First();
        }

    }
}
