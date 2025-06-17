using Microsoft.EntityFrameworkCore;
using Poultry_management_System.Controllers;
using Poultry_management_System.Data.Entities;

namespace Poultry_management_System.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<Expense> Expense { get; set; }
        public DbSet<DailyCapture> DailyCapture { get; set; }
        public DbSet<DefaultPrices> CaptureSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DailyCapture>().HasData(new DailyCapture
            {
                Id = 1,
                TraysPrice = 65.00M,
                TwelvesPrice = 35.00M,
                SixesPrice = 20.00M,
                DateCaptured = new DateTime(2025, 05, 13)
            });
        }

    }
}
