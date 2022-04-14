using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Windows;
using WpfTest.Interfaces;
using WpfTest.Services;
using WpfTest.ViewModels;

namespace WpfTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //public static Window ActiveWindow => Application.Current.Windows
        //    .OfType<Window>()
        //    .FirstOrDefault(w => w.IsActive);


        //public static Window FocusedWindow => Application.Current.Windows
        //    .OfType<Window>()
        //    .FirstOrDefault(w => w.IsFocused);


        //public static Window CurrentWindow => FocusedWindow ?? ActiveWindow;


        public static bool IsDesignTime { get; private set; } = true;


        private static IHost __Host;

        public static IHost Host => __Host
            ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();


        

        public static IServiceProvider Services => Host.Services;


        internal static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            ConfigApp.Token = host.Configuration["Token"];
            ConfigApp.SomeValues = host.Configuration["SomeValues"];
            
            services.AddViewModels();
            services.AddHttpClient<StockdataClient>(client => client.BaseAddress = new Uri(host.Configuration["StockUri"]));

            services.AddTransient<IStringConverter, StringConverter>();
        }
        


        protected override async void OnStartup(StartupEventArgs e)
        {
            IsDesignTime = false;
            var host = Host;



            using (var scope = Services.CreateScope())
            {
                //await scope.ServiceProvider.GetRequiredService<DbInitializer>().InitializeAsync();
                //Configuration.Bind("Project", new CongigApp());
            }


            base.OnStartup(e);
            await host.StartAsync();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using var host = Host;
            base.OnExit(e);
            await host.StopAsync();
        }
    }
}
