using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class GuestController : Controller
    {
        private readonly IGuestService _guestService;
        private readonly IRoomService _roomService;
        private readonly IBookingService _bookingService;

        public GuestController(IGuestService customerService, IRoomService roomService, IBookingService bookingService)
        {
            _guestService = customerService;
            _roomService = roomService;
            _bookingService = bookingService;
        }

        public IActionResult Index()
        {
            ViewBag.Rooms = _roomService.GetList().Data;
            var model = _guestService.GetList().Data;
            return View(model);
        }

        public IActionResult AddGuest()
        {
            ViewBag.Rooms = new SelectList(_roomService.GetList().Data, "ID", "RoomNumber");
            return View();
        }

        [HttpPost]
        public IActionResult AddGuest(Guest guest)
        {
            guest.CheckIn = guest.CheckIn.AddHours(14);
            guest.CheckOut = guest.CheckOut.AddHours(10);
            if (ModelState.IsValid)
            {
                var result = _guestService.Add(guest);
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }
            return View(guest);
        }

        public IActionResult UpdateGuest(int id)
        {
            var updated = _guestService.GetById(id).Data;

            ViewBag.Rooms = new SelectList(_roomService.GetList().Data, "ID", "RoomNumber",updated.RoomId);

            return View(updated);
        }

        [HttpPost]
        public IActionResult UpdateGuest(Guest guest)
        {
            if (ModelState.IsValid)
            {
                var result = _guestService.Update(guest);
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }
            return View(guest);
        }
        public IActionResult DeleteGuest(int id)
        {
            var deleted = _guestService.GetById(id).Data;

            return View(deleted);
        }

        [HttpPost]
        public IActionResult DeleteGuest(Guest guest)
        {
            try
            {
                _guestService.Delete(guest);
                return RedirectToAction("Index");
            }
            catch 
            {
                return View(guest);
            }
        }
    }
}
