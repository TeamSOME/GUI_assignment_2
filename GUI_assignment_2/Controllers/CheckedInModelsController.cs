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

namespace GUI_assignment_2.Controllers
{
    [Authorize("Reception")]
    public class CheckedInModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CheckedInModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CheckedInModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.CheckedInModels.ToListAsync());
        }

        // GET: CheckedInModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkedInModel = await _context.CheckedInModels
                .FirstOrDefaultAsync(m => m.CheckedInModelID == id);
            if (checkedInModel == null)
            {
                return NotFound();
            }

            return View(checkedInModel);
        }

        // GET: CheckedInModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CheckedInModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CheckedInModelID,Date,RoomNumber,Kids,Adults")] CheckedInModel checkedInModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkedInModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(checkedInModel);
        }

        // GET: CheckedInModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkedInModel = await _context.CheckedInModels.FindAsync(id);
            if (checkedInModel == null)
            {
                return NotFound();
            }
            return View(checkedInModel);
        }

        // POST: CheckedInModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CheckedInModelID,Date,RoomNumber,Kids,Adults")] CheckedInModel checkedInModel)
        {
            if (id != checkedInModel.CheckedInModelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checkedInModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckedInModelExists(checkedInModel.CheckedInModelID))
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
            return View(checkedInModel);
        }

        // GET: CheckedInModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkedInModel = await _context.CheckedInModels
                .FirstOrDefaultAsync(m => m.CheckedInModelID == id);
            if (checkedInModel == null)
            {
                return NotFound();
            }

            return View(checkedInModel);
        }

        // POST: CheckedInModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var checkedInModel = await _context.CheckedInModels.FindAsync(id);
            _context.CheckedInModels.Remove(checkedInModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckedInModelExists(int id)
        {
            return _context.CheckedInModels.Any(e => e.CheckedInModelID == id);
        }
    }
}
