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
    [Authorize("Restaurant")]
    public class OrderModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrderModels/Create
        public async Task<IActionResult> Create(long? id)
        {
            if (id == null)
            {
                return View(new CheckedInModel());
            }

            var newOrder = await _context.OrderModels.FindAsync(id);
            if (newOrder == null)
            {
                return NotFound();
            }

            return View(newOrder);
        }

        // POST: OrderModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomNumber,CheckedInAdults,CheckedInKids")] CheckedInModel checkedInOrder)
        {
            OrderModel newOrder;

            try
            {
                newOrder = await _context.OrderModels.Where(p => p.RoomNumber == checkedInOrder.RoomNumber).FirstAsync();
            }
            catch
            {
                ModelState.AddModelError("RoomNumber","This room is not occupied");
                return View(checkedInOrder);
            }

            newOrder.CheckedInAdults = checkedInOrder.CheckedInAdults;
            newOrder.CheckedInKids = checkedInOrder.CheckedInKids;


            if (ModelState.IsValid)
            {
                _context.Update(newOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View(checkedInOrder);
        }
    }
}
