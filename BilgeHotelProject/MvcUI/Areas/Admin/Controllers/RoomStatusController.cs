using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomStatusController:Controller
    {
        private readonly IRoomStatusService _roomStatusService;

        public RoomStatusController(IRoomStatusService roomStatusService)
        {
            _roomStatusService = roomStatusService;
        }

        public IActionResult Index()
        {
            var model = _roomStatusService.GetList().Data;
            return View(model);
        }

        public IActionResult AddRoomStatus()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRoomStatus(RoomStatus roomStatus)
        {
            if (ModelState.IsValid)
            {
                _roomStatusService.Add(roomStatus);
                return RedirectToAction("Index");
            }
            return View(roomStatus);
        }

        public IActionResult UpdateRoomStatus(int id)
        {
            var updated = _roomStatusService.GetById(id).Data;

            return View(updated);
        }

        [HttpPost]
        public IActionResult UpdateRoomStatus(RoomStatus roomStatus)
        {
            if (ModelState.IsValid)
            {
                _roomStatusService.Update(roomStatus);
                return RedirectToAction("Index");
            }
            return View(roomStatus);
        }

        public IActionResult DeleteRoomStatus(int id)
        {
            var deleted = _roomStatusService.GetById(id).Data;

            return View(deleted);
        }

        [HttpPost]
        public IActionResult DeleteRoomStatus(RoomStatus roomStatus)
        {
            try
            {
                _roomStatusService.Delete(roomStatus);
                return RedirectToAction("Index");
            }
            catch 
            {
                return View(roomStatus);
            }
        }
    }
}
