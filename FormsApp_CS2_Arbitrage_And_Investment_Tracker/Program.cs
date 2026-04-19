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
        public static IConfiguration Configuration { get; private set; }
        public static IServiceProvider ServiceProvider { get; private set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //load configurtation
            Configuration = new ConfigurationBuilder()
             .SetBasePath(AppContext.BaseDirectory)
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
             .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
             .Build();

            // Setup DI Container
            var services = new ServiceCollection();

            // Register DbContext
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<CS2TrackerContext>(options =>
                options.UseSqlServer(connectionString));

            // Register Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEntryService, EntryService>();
            services.AddScoped<ISheetService, SheetService>();

            ServiceProvider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(new CS2TrackerContext(connectionString)));
        }
    }
}