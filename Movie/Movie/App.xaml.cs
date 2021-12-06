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
            services.AddSingleton<MainWindow>();
            //services.AddDbContext<CinemaContext>(option => option.UseSqlServer(ConfigurationManager.ConnectionStrings["mainConnection"].ConnectionString));
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            serviceProvider.GetService<MainWindow>().Show();
        }
    }
}
