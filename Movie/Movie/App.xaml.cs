using BLL.Services;
using DLL.Context;
using DLL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Movie
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            var collection = new ServiceCollection();
            ConfigureService(collection);
            serviceProvider = collection.BuildServiceProvider();
        }

        private void ConfigureService(ServiceCollection services)
        {
            //Window
            services.AddSingleton<MainWindow>();
            services.AddTransient<AuthorizationWindow>();
            //Context
            services.AddDbContext<CinemaContext>(option => option.UseSqlServer(ConfigurationManager.ConnectionStrings["mainConnection"].ConnectionString));
            //Repository
            services.AddTransient<BookingRepository>();
            services.AddTransient<CinemaHallRepository>();
            services.AddTransient<EmployeeRepository>();
            services.AddTransient<FilmRepository>();
            services.AddTransient<LoginDataRepository>();
            services.AddTransient<PlaceRepository>();
            services.AddTransient<SessionRepository>();
            //Service
            services.AddTransient<AdminService>();
            services.AddTransient<AuthorizationService>();
            services.AddTransient<SessionService>();
            services.AddTransient<TicketService>();
            
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            serviceProvider.GetService<MainWindow>().Show();
        }
    }
}
