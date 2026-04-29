using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Context;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.GUI.Entries;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.GUI.MainApp;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.GUI.UserConrols;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Interfaces.IServices;
using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();

            var services = new ServiceCollection();

            var connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<CS2TrackerContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEntryService, EntryService>();
            services.AddScoped<ISheetService, SheetService>();

            services.AddScoped<Form1>();
            services.AddScoped<ucCreateUser>();
            services.AddScoped<ucLoginUser>();
            services.AddScoped<ucMainApp>();
            services.AddScoped<ucCreateSheet>();
            services.AddScoped<ucAddEntry>();

            ServiceProvider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();

            Application.Run(ServiceProvider.GetRequiredService<Form1>());
        }
    }
}