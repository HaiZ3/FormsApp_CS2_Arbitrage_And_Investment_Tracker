using FormsApp_CS2_Arbitrage_And_Investment_Tracker.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FormsApp_CS2_Arbitrage_And_Investment_Tracker.Context
{
    public class CS2TrackerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Sheet> Sheets { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<SkinInfo> SkinInfos { get; set; }
        public DbSet<DailyStat> DailyStats { get; set; }
        public DbSet<OverallStat> OverallStats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sheet>()
                .HasOne(s => s.User)
                .WithMany(u => u.Sheets)
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<Entry>()
                .HasOne(s => s.Sheet)
                .WithMany(e => e.Entries)
                .HasForeignKey(s => s.SheetId);

            modelBuilder.Entity<Entry>()
                .HasOne(e => e.SkinInfo)
                .WithOne(s => s.Entry)
                .HasForeignKey<SkinInfo>(s => s.EntryId)
                .OnDelete(DeleteBehavior.Cascade);

            //Sets each decimal to the same precision and scale in the database
            foreach (var property in modelBuilder.Model
               .GetEntityTypes()
               .SelectMany(t => t.GetProperties())
               .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetPrecision(18);
                property.SetScale(2);
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
