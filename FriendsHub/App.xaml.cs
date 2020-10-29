using FriendsHub.Data;
using FriendsHub.Services.Data;
using FriendsHub.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FriendsHub
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IConfiguration Configuration { get; private set; }
        public IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            // build appsettings.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
             Configuration = builder.Build();

            //service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // service provider
             ServiceProvider = serviceCollection.BuildServiceProvider();
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            //display the main window
            mainWindow.Show();


        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IEventAggregator, EventAggregator>();
            services.AddDbContext<CatalogContext>(cfg => cfg.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient(typeof(MainWindow));
            services.AddTransient(typeof(MainViewModel));
            services.AddTransient<NavigationViewModel>();
            services.AddTransient<FriendDetailViewModel>();
            services.AddScoped<IDataService, DataService>();
            services.AddScoped<IFriendLookupService, LookupService>();
           
        }
    }
}
