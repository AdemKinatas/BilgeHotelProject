using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class BookingPackageController : Controller
    {
        private readonly IBookingPackageService _bookingPackageService;

        public BookingPackageController(IBookingPackageService bookingPackageService)
        {
            _bookingPackageService = bookingPackageService;
        }

        public IActionResult Index()
        {
            var model = _bookingPackageService.GetList().Data;
            return View(model);
        }

        public IActionResult AddBookingPackage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBookingPackage(BookingPackage bookingPackage)
        {
            if (ModelState.IsValid)
            {
                _bookingPackageService.Add(bookingPackage);
                return RedirectToAction("Index");
            }
            return View(bookingPackage);
        }

        public IActionResult UpdateBookingPackage(int id)
        {
            var updated = _bookingPackageService.GetById(id).Data;

            return View(updated);
        }

        [HttpPost]
        public IActionResult UpdateBookingPackage(BookingPackage bookingPackage)
        {
            if (ModelState.IsValid)
            {
                _bookingPackageService.Update(bookingPackage);
                return RedirectToAction("Index");
            }
            return View(bookingPackage);
        }

        public IActionResult DeleteBookingPackage(int id)
        {
            var deleted = _bookingPackageService.GetById(id).Data;
            return View(deleted);
        }

        [HttpPost]
        public IActionResult DeleteBookingPackage(BookingPackage bookingPackage)
        {
            try
            {
                _bookingPackageService.Delete(bookingPackage);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(bookingPackage);
            }
        }
    }
}
