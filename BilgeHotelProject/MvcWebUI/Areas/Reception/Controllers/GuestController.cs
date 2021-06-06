using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Areas.Reception.Controllers
{
    [Authorize(Roles = "Admin,Reception")]
    [Area("Reception")]
    public class GuestController : Controller
    {
        private readonly IGuestService _guestService;
        private readonly IRoomService _roomService;

        public GuestController(IGuestService customerService, IRoomService roomService)
        {
            _guestService = customerService;
            _roomService = roomService;
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
            if (ModelState.IsValid)
            {
                _guestService.Add(guest);
                return RedirectToAction("Index");
            }
            return View(guest);
        }

        public IActionResult UpdateGuest(int id)
        {
            var updated = _guestService.GetById(id).Data;

            ViewBag.Rooms = new SelectList(_roomService.GetList().Data, "ID", "RoomNumber", updated.RoomId);

            return View(updated);
        }

        [HttpPost]
        public IActionResult UpdateGuest(Guest guest)
        {
            if (ModelState.IsValid)
            {
                _guestService.Update(guest);
                return RedirectToAction("Index");
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
