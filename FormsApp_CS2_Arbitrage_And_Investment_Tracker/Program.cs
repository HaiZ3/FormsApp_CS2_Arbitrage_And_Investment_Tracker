using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Context;
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

            ServiceProvider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();

            var db = ServiceProvider.GetRequiredService<CS2TrackerContext>();
            var form = new Form1(db);

            Application.Run(form);
        }
    }
}