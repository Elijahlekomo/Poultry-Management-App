using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;
using Poultry_management_System.Data;
using Poultry_management_System.Data.Entities;
using Poultry_management_System.Models;

namespace Poultry_management_System.Controllers
{
    public class CaptureEntryController : Controller
    {
        private readonly DataContext _context;

        public CaptureEntryController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //  var viewModel = new CaptureFormViewModel();

            var CaptureForm = await _context.DailyCapture.ToListAsync();
            return View(CaptureForm);
        }

        // GET: CaptureEntry/Create
        public IActionResult Create()
        {

            var settings = _context.DailyCapture.Find(1);

            var viewModel = new CaptureFormViewModel()
            {
                TrayPrice = settings?.TraysPrice ?? 0,
                TwelvesPrice = settings?.TwelvesPrice ?? 0,
                SixesPrice = settings?.SixesPrice ?? 0
            };
            return View(viewModel);
        }
        //public IActionResult Create()
        //{
        //    var seed = _context.DailyCapture.Find(1);
        //    var vm = new CaptureFormViewModel
        //    {
        //        TrayPrice = seed?.TraysPrice ?? 0,
        //        TwelvesPrice = seed?.TwelvesPrice ?? 0,
        //        SixesPrice = seed?.SixesPrice ?? 0
        //    };
        //    return View(vm);
        //}


        // POST: CaptureEntry/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CaptureFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var settings = _context.DailyCapture.FirstOrDefault();

                var entity = new DailyCapture
                {
                    LeftoverEggs = model.LeftOverEggs,
                    UnsoldEggs = model.UnsoldEggs,
                    DamagedEggs = model.DamagedEggs,
                    SoldTwelves = model.SoldTwelves,
                    SoldSixes = model.SoldSixes,
                    SoldTrays = model.SoldTrays,
                    UnsoldTrays = model.UnsoldTrays,
                    //TraysPrice = model.TrayPrice,
                    //SixesPrice = model.SixesPrice,
                    //TwelvesPrice = model.TwelvesPrice,
                    Amount = model.Amount,
                    TotalAmount = model.TotalAmount,
                    DateCaptured = model.DateCaptured,
                };

                _context.DailyCapture.Add(entity);
                await _context.SaveChangesAsync();

                // Redirect to index after successful capture
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var entry = await _context.DailyCapture.FindAsync(id);
            if (entry == null)
            {
                return NotFound();
            }

            var viewModel = new CaptureFormViewModel
            {
                Id = entry.Id,
                LeftOverEggs = entry.LeftoverEggs,
                UnsoldEggs = entry.UnsoldEggs,
                DamagedEggs = entry.DamagedEggs,
                SoldTwelves = entry.SoldTwelves,
                SoldSixes = entry.SoldSixes,
                SoldTrays = entry.SoldTrays,
                UnsoldTrays = entry.UnsoldTrays,
                TrayPrice = entry.TraysPrice,
                SixesPrice = entry.SixesPrice,
                TwelvesPrice = entry.TwelvesPrice,
                Amount = entry.Amount,
                TotalAmount = entry.TotalAmount,
                DateCaptured = entry.DateCaptured,

            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CaptureFormViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Update your database logic here
                var capture = await _context.DailyCapture.FindAsync(id);
                if (capture == null)
                {
                    return NotFound();
                }

                // Map updated properties from the model to the entity
                capture.LeftoverEggs = model.LeftOverEggs;
                capture.DamagedEggs = model.DamagedEggs;
                capture.TraysPrice = model.TrayPrice;
                capture.TwelvesPrice = model.TwelvesPrice;
                capture.SixesPrice = model.SixesPrice;
                capture.SoldTrays = model.SoldTrays;
                capture.SoldTwelves = model.SoldTwelves;
                capture.SoldSixes = model.SoldSixes;
                capture.UnsoldTrays = model.UnsoldTrays;
                capture.UnsoldEggs = model.UnsoldEggs;
                capture.Amount = model.Amount;
                capture.TotalAmount = model.TotalAmount;
                capture.DateCaptured = model.DateCaptured;

                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Capture updated successfully!";
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(CaptureFormViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    var entry = await _context.DailyCapture.FindAsync(model.Id);
        //    if (entry == null)
        //    {
        //        return NotFound();
        //    }

        //    entry.TotalTrays = model.TotalTrays;
        //    entry.LeftoverEggs = model.LeftOverEggs;
        //    entry.DamagedEggs = model.DamagedEggs;
        //    entry.SoldTwelves = model.SoldTwelves;
        //    entry.SoldSixes = model.SoldSixes;
        //    entry.UnsoldTrays = model.UnsoldTrays;
        //    entry.UnsoldEggs = model.UnsoldEggs;
        //    entry.TraysPrice = model.TrayPrice;
        //    entry.TwelvesPrice = model.TwelvesPrice;
        //    entry.SixesPrice = model.SixesPrice;
        //    entry.Amount = model.Amount;
        //    entry.TotalAmount = model.TotalAmount;
        //    entry.DateCaptured = model.DateCaptured;
        //    _context.DailyCapture.Update(entry);
        //    await _context.SaveChangesAsync();

        //    return RedirectToAction("Index");
        //}


        // POST: CaptureEntry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var capture = await _context.DailyCapture.FindAsync(id);
            if (capture == null)
                return NotFound();

            _context.DailyCapture.Remove(capture);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
