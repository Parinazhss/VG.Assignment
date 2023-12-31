
using Addressbook.Shared.Service;
using Addressbook.Shared.ViewModels;
using Addressbook.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System.Windows;

namespace Addressbook
{

    public partial class App : Application
    {
        private IHost? _host;

        public App() 
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddSingleton<ContactService> ();
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<MainViewModel>();
                    services.AddTransient<ContactListViewModel>();
                    services.AddTransient<ContactListView>();
                    services.AddTransient<ContactAddViewModel>();

                })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host!.Start();

            var mainWindow = _host!.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }

   
    
}
