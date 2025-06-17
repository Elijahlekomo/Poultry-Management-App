using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;
using Poultry_management_System.Data;
using Poultry_management_System.Data.Entities;
using X.PagedList;
using Poultry_management_System.Models;
using X.PagedList.Extensions;
using X.PagedList.EF;

namespace Poultry_management_System.Controllers
{
    //[Area("Capture")]
    public class ExpenseController : Controller
    {
        private readonly DataContext _context;

        public ExpenseController(DataContext context)
        {
            _context = context;
        }



        public async Task<IActionResult> Index(int? page)
        {

            int pageSize = 10;
            int pageNumber = page ?? 1;

            var data = _context.Expense.OrderByDescending(e => e.DateCaptured);

            return View(await data.ToPagedListAsync(pageNumber, pageSize));
        }

        // GET: CaptureEntry/Create

        public IActionResult Create()
        {
            var viewModel = new ExpensesViewModel();
            return View(viewModel);
        }

        // POST: CaptureEntry/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ExpensesViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new Expense
                {
                    StarterFeed = model.StarterFeed,
                    LayerFeed = model.LayerFeed,
                    GrowerFeed = model.GrowerFeed,
                    TotalChickens = model.TotalChickens,
                    TotalChicks = model.TotalChicks,
                    StarterDied = model.StarterDied,
                    LayersDied = model.LayersDied,
                    ElectricityHouse1 = model.House1Electricity,
                    ElectricityHouse2 = model.House2Electricity,
                    WaterCost = model.WaterCost,
                    TownLunch = model.TownLunch,
                    TownTransport = model.TownTransport,
                    DateCaptured = model.DateCaptured,
                };

                _context.Expense.Add(entity);
                await _context.SaveChangesAsync();

                // Redirect to index after successful capture
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var entry = await _context.Expense.FindAsync(id);
            if (entry == null)
            {
                return NotFound();
            }

            var viewModel = new ExpensesViewModel
            {
                Id = entry.Id,
                StarterFeed = entry.StarterFeed,
                LayerFeed = entry.LayerFeed,
                GrowerFeed = entry.GrowerFeed,
                TotalChickens = entry.TotalChickens,
                TotalChicks = entry.TotalChicks,
                StarterDied = entry.StarterDied,
                LayersDied = entry.LayersDied,
                House1Electricity = entry.ElectricityHouse1,
                House2Electricity = entry.ElectricityHouse2,
                WaterCost = entry.WaterCost,
                TownLunch = entry.TownLunch,
                TownTransport = entry.TownTransport,
                DateCaptured = entry.DateCaptured,
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Expense model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var entry = await _context.Expense.FindAsync(model.Id);
            if (entry == null)
            {
                return NotFound();
            }

            //entry.TotalTrays = model.TotalTrays;
            entry.StarterFeed = model.StarterFeed;
            entry.LayerFeed = model.LayerFeed;
            entry.GrowerFeed = model.GrowerFeed;
            entry.TotalChickens = model.TotalChickens;
            entry.TotalChicks = model.TotalChicks;
            entry.StarterDied = model.StarterDied;
            entry.LayersDied = model.LayersDied;
            entry.ElectricityHouse1 = model.ElectricityHouse1;
            entry.DateCaptured = model.DateCaptured;
            _context.Expense.Update(entry);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        // POST: CaptureEntry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var capture = await _context.Expense.FindAsync(id);
            if (capture == null)
                return NotFound();

            _context.Expense.Remove(capture);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index)); // Go back to listing page
        }

    }
}
