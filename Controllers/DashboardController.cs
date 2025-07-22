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
                //TotalMonthlyIncome = _context.Captures.Where(c => c.Date >= monthStart).Sum(c => c.SalesAmount),
                //TotalMonthlyExpense = _context.Captures.Where(c => c.Date >= monthStart).Sum(c => c.TotalExpense),
                //// Profit = Income - Expense
                //TotalMonthlyProfit = _context.Captures.Where(c => c.Date >= monthStart).Sum(c => c.SalesAmount - c.TotalExpense),

                // Daily Overview
                //TotalDailyIncome = _context.Captures.Where(c => c.Date == today).Sum(c => c.SalesAmount),
                //TotalDailyExpense = _context.Captures.Where(c => c.Date == today).Sum(c => c.TotalExpense),
                //TotalDailyProfit = _context.Captures.Where(c => c.Date == today).Sum(c => c.SalesAmount - c.TotalExpense),

                // Daily Operations Summary
                //TotalTrays = _context.Captures.Where(c => c.Date == today).Sum(c => c.Trays),
                //SoldTrays = _context.Captures.Where(c => c.Date == today).Sum(c => c.Sold),
                //LeftoverEggs = _context.Captures.Where(c => c.Date == today).Sum(c => c.UnsoldEggs),
                //DamagedEggs = _context.Captures.Where(c => c.Date == today).Sum(c => c.Damaged),
                //DeathReport = _context.Captures.Where(c => c.Date == today).Sum(c => c.DeathReport),
                //TotalFeedUsed = _context.Captures.Where(c => c.Date == today).Sum(c => c.FeedBags),

                // Stock
                //TotalChickens = _context.Captures.OrderByDescending(c => c.Date).FirstOrDefault()?.TotalChickens ?? 0,
                //TotalFeedStock = _context.Captures.OrderByDescending(c => c.Date).FirstOrDefault()?.TotalFeedStock ?? 0
            };

            return View(model);
        }
    }

}
