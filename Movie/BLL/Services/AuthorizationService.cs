using DLL.Context;
using DLL.Models;
using DLL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthorizationService
    {
        private CinemaContext context;
        public AuthorizationService(CinemaContext context)
        {
            this.context = context;
        }

        public async Task<LoginData> Authorization(string email, string pass)
        {
            LoginDataRepository LoginDataRepository = new(context);

            var Login = await LoginDataRepository.FindByConditionAsync(x => x.Login == email && x.Password == pass);

            var log = (List<LoginData>)Login;

            return log[0];
        }

        



    }
}
