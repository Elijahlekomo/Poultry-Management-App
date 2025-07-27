using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Poultry_management_System.Data;
using Poultry_management_System.Models;

namespace Poultry_management_System.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly DataContext _context;

        public DashboardController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var today = DateTime.Today;
            var monthStart = new DateTime(today.Year, today.Month, 1);

            var model = new DashboardViewModel
            {
                Date = today,

                // Monthly Overview
                TotalMonthlyIncome = _context.DailyCapture.Where(c => c.DateCaptured >= monthStart).Sum(c => c.TotalAmount),
                TotalMonthlyExpense = _context.Expense.Where(c => c.DateCaptured >= monthStart).Sum(c => c.TownLunch + c.TownTransport),
                // Profit = Income - Expense
                TotalMonthlyProfit = _context.DailyCapture.Where(c => c.DateCaptured >= monthStart).Sum(c => c.TotalAmount) - _context.Expense.Where(c => c.DateCaptured >= monthStart).Sum(c => c.TownLunch + c.TownTransport),

                // Daily Overview
                TotalDailyIncome = _context.DailyCapture.Where(c => c.DateCaptured == today).Sum(c => c.TotalAmount),
                TotalDailyExpense = _context.Expense.Where(c => c.DateCaptured == today).Sum(c => c.TownLunch + c.TownTransport),
                TotalDailyProfit = _context.DailyCapture.Where(c => c.DateCaptured == today).Sum(c => c.TotalAmount) - _context.Expense.Where(c => c.DateCaptured == today).Sum(c => c.TownLunch + c.TownTransport),

                // Daily Operations Summary
                TotalTrays = _context.DailyCapture.Where(c => c.DateCaptured == today).Sum(c => c.SoldTrays + c.UnsoldTrays),
                SoldTrays = _context.DailyCapture.Where(c => c.DateCaptured == today).Sum(c => c.SoldTrays),
                LeftoverEggs = _context.DailyCapture.Where(c => c.DateCaptured == today).Sum(c => c.UnsoldEggs),
                DamagedEggs = _context.DailyCapture.Where(c => c.DateCaptured == today).Sum(c => c.DamagedEggs),
                DeathReport = _context.Expense.Where(c => c.DateCaptured == today).Sum(c => c.StarterDied + c.LayersDied),
                TotalFeedUsed = _context.Expense.Where(c => c.DateCaptured == today).Sum(c => c.GrowerFeed + c.LayerFeed + c.StarterFeed),

                // Stock
                TotalChickens = _context.Expense.OrderByDescending(c => c.DateCaptured).FirstOrDefault()?.TotalChickens ?? 0,
                TotalFeedStock = _context.Expense.OrderByDescending(c => c.DateCaptured).FirstOrDefault()?.TotalFeeds ?? 0
            };

            return View(model);
        }
    }

}
