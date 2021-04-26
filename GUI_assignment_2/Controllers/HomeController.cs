using GUI_assignment_2.Data;
using GUI_assignment_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace GUI_assignment_2.Controllers
{
    public class HomeController : Controller
    {
        //[Authorize]
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        #region PAGES
        public IActionResult Index()
        {
            return View();
        }
        //[Authorize("Reception")]
        public IActionResult Reception()
        {
            return View();
        }
        //[Authorize(Roles = "Chef")]
        //[Authorize("Kitchen")]
        //public IActionResult Kitchen()
        //{
        //    return View();
        //}
        //[Authorize("Restaurant")]
        //public IActionResult Restaurant()
        //{
        //    return View();
        //}

        public IActionResult Login()
        {
            return View();
        }

        #endregion



        #region ACTION------------------------------------------------------------------------------------------

        #region KITCHEN??? RESTAURANT???
        //[Authorize("Kitchen")]
        //[Authorize(Roles = "Chef")]
        //[HttpPost]
        public async Task<IActionResult> Kitchen(string id)
        {
            DateTime date = Convert.ToDateTime(id);
            var OrderModel = await _db.OrderModels.Where(m => m.Date.Date == date.Date).ToListAsync();
            var totalAdultsDate = 0;
            var totalKidsDate = 0;
            //var total = 0;
            var checkedInAdults = 0;
            var checkedInKids = 0;
            //var remainingAdults = 0;
            //var remainingKids = 0;
            //var remainingTotal = 0;


            var KitchenModel = new KitchenModel //sættes til lokal variabel
            {
                TotalAdultsDate = totalAdultsDate,
                TotalKidsDate = totalKidsDate,
                Total = totalAdultsDate+totalKidsDate,
                CheckedInAdults = checkedInAdults,
                CheckedInKids = checkedInKids,
                RemainingAdults = totalAdultsDate- checkedInAdults,
                RemainingKids = totalKidsDate- checkedInKids,
                RemainingTotal = (totalKidsDate - checkedInKids)+(totalAdultsDate - checkedInAdults),
                Date = date.ToString("g"),
            };

            foreach (var OrderModels in OrderModel) //For hver order ligges det op
            {
                totalAdultsDate += OrderModels.Adults;
                checkedInAdults += OrderModels.CheckedInAdults;
                totalKidsDate += OrderModels.Kids;
                checkedInKids += OrderModels.CheckedInKids;

            }

            if (OrderModel == null)
            { return NotFound(); }

            return View(KitchenModel);
        }

        #endregion //kitchen

        #region RESTAURANT

        //[Authorize("Restaurant")]
        //[Authorize(Roles = "Admin")]


        public async Task<IActionResult> Restaurant(string id)
        {
            var OrderModel = await _db.OrderModels.FindAsync(id);

            if (id == null)
            {
                return View(new OrderModel());
            }
            if (OrderModel == null)
            {
                return NotFound();
            }

            return View(OrderModel);
        }

        //[Authorize("Restaurant")]
        [HttpPost]

        //Validation
        public async Task<IActionResult> Restaurant([Bind("RoomNumber, CheckedInAdults, CheckedInKids")] OrderModel checkedIn)
        {
            OrderModel OrderModels;
            OrderModels = await _db.OrderModels.Where(x => x.RoomNumber == checkedIn.RoomNumber && x.Date == DateTime.Now.Date).FirstAsync();
            OrderModels.CheckedInAdults = checkedIn.CheckedInAdults;
            OrderModels.CheckedInKids = checkedIn.CheckedInKids;

            if (ModelState.IsValid)
            {
                _db.Update(OrderModels);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(HomeController.Index)); //Tror jeg?
            }

            return View(checkedIn);
        }
        #endregion //restaurant

        #region Reception

        //[Authorize("Reception")]
        //[Authorize(Roles = "Receptionist")]
        [HttpPost]
        public async Task<IActionResult> Reception([Bind("RoomNumber,Date,Adults,Kids,CheckedInAdults,CheckedInKids")] OrderModel checkedIn)//Mangler det der skal bindes
        {
            

            if (ModelState.IsValid)
            {
                _db.Add(checkedIn);//ved ikke om det her er rigtigt
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(HomeController.Reception)); //Tror jeg?
            }
            return View(checkedIn);
        }
        #endregion //Reception
        #endregion //ACTION BABY

    }//class
}//namespace