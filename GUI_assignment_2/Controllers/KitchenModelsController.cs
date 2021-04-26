using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GUI_assignment_2.Data;
using GUI_assignment_2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace GUI_assignment_2.Controllers
{
    [Authorize("Kitchen")]
    public class KitchenModelsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public KitchenModelsController(ApplicationDbContext db, ILogger<HomeController> logger)
        {
            _db = db;
            _logger = logger;
        }

        // GET: KitchenModels
        public async Task<IActionResult> Index()
        {
            return View(await _db.kitchenModels.ToListAsync());
        }

        // GET: KitchenModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitchenModel = await _db.kitchenModels
                .FirstOrDefaultAsync(m => m.KitchenModelID == id);
            if (kitchenModel == null)
            {
                return NotFound();
            }

            return View(kitchenModel);
        }

        // GET: KitchenModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KitchenModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KitchenModelID,TotalAdultsDate,TotalKidsDate,Total,CheckedInAdults,CheckedInKids,RemainingAdults,RemainingKids,RemainingTotal,Date")] KitchenModel kitchenModel)
        {
            if (ModelState.IsValid)
            {
                _db.Add(kitchenModel);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kitchenModel);
        }

        // GET: KitchenModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitchenModel = await _db.kitchenModels.FindAsync(id);
            if (kitchenModel == null)
            {
                return NotFound();
            }
            return View(kitchenModel);
        }

        // POST: KitchenModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KitchenModelID,TotalAdultsDate,TotalKidsDate,Total,CheckedInAdults,CheckedInKids,RemainingAdults,RemainingKids,RemainingTotal,Date")] KitchenModel kitchenModel)
        {
            if (id != kitchenModel.KitchenModelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(kitchenModel);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KitchenModelExists(kitchenModel.KitchenModelID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(kitchenModel);
        }

        // GET: KitchenModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitchenModel = await _db.kitchenModels
                .FirstOrDefaultAsync(m => m.KitchenModelID == id);
            if (kitchenModel == null)
            {
                return NotFound();
            }

            return View(kitchenModel);
        }

        // POST: KitchenModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kitchenModel = await _db.kitchenModels.FindAsync(id);
            _db.kitchenModels.Remove(kitchenModel);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KitchenModelExists(int id)
        {
            return _db.kitchenModels.Any(e => e.KitchenModelID == id);
        }

        public async Task<IActionResult> Kitchen(string id)
        {
            DateTime date = Convert.ToDateTime(id);
            var OrderModel = await _db.OrderModels.Where(a => a.Date.Date == date.Date).ToListAsync();
            if (OrderModel == null)
            {
                return NotFound();
            }
            var totalAdultsDate = 0;
            var totalKidsDate = 0;
            //var total = 0;
            var checkedInAdults = 0;
            var checkedInKids = 0;
            //var remainingAdults = 0;
            //var remainingKids = 0;
            //var remainingTotal = 0;

            foreach (var orderModels in OrderModel) //For hver order ligges det op
            {
                totalAdultsDate += orderModels.Adults;
                checkedInAdults += orderModels.CheckedInAdults;
                totalKidsDate += orderModels.Kids;
                checkedInKids += orderModels.CheckedInKids;

            }

            var KitchenModel = new KitchenModel //sættes til lokal variabel
            {
                TotalAdultsDate = totalAdultsDate,
                TotalKidsDate = totalKidsDate,
                Total = totalAdultsDate + totalKidsDate,
                CheckedInAdults = checkedInAdults,
                CheckedInKids = checkedInKids,
                RemainingAdults = totalAdultsDate - checkedInAdults,
                RemainingKids = totalKidsDate - checkedInKids,
                RemainingTotal = (totalKidsDate - checkedInKids) + (totalAdultsDate - checkedInAdults),
                Date = date.ToString("yyyy-MM-dd"),
            };

            return View(KitchenModel);
        }
    }
}
