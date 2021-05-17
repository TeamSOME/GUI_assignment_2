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
        private readonly ApplicationDbContext _db;

        public KitchenModelsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: KitchenModels
        public async Task<IActionResult> Index(string id)
        {
            DateTime date = Convert.ToDateTime(id);
            var OrderModel = await _db.OrderModels.Where(a => a.Date.Date == date.Date).ToListAsync();
            if (OrderModel == null)
            {
                return NotFound();
            }
            var totalAdultsDate = 0;
            var totalKidsDate = 0;
            var checkedInAdults = 0;
            var checkedInKids = 0;

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
