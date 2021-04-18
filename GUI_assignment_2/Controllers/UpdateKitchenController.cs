using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUI_assignment_2.Controllers
{
    public class UpdateKitchenController : Controller
    {
        // GET: UpdateKitchenController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UpdateKitchenController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UpdateKitchenController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UpdateKitchenController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UpdateKitchenController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UpdateKitchenController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UpdateKitchenController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UpdateKitchenController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
