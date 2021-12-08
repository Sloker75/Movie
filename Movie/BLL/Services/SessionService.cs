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
    public class SessionService
    {
        private CinemaContext context;
        public SessionService(CinemaContext context)
        {
            this.context = context;
        }


        public async void AddSession(Session session)
        {
            SessionRepository sessionRepository = new(context);

            await sessionRepository.CreateAsync(session);
        }


    }
}
