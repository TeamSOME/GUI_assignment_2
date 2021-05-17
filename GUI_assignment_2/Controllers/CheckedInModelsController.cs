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
            return View(await _context.OrderModels.ToListAsync());
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
        public async Task<IActionResult> Create([Bind("RoomNumber,Date,Adults,Kids,CheckedInAdults,CheckedInKids")] OrderModel orderModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderModel);
        }
    }
}
