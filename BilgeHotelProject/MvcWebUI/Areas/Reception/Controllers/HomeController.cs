using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Areas.Reception.Controllers
{
    [Authorize(Roles = "Admin,Reception")]
    [Area("Reception")]
    public class HomeController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly IRoomTypeService _roomTypeService;
        private readonly IRoomStatusService _roomStatusService;
        private readonly IRoomImageService _roomImageService;
        private readonly IBookingService _bookingService;

        public HomeController(IRoomService roomService, IRoomTypeService roomTypeService, IRoomStatusService roomStatusService, IRoomImageService roomImageService, IBookingService bookingService)
        {
            _roomService = roomService;
            _roomTypeService = roomTypeService;
            _roomStatusService = roomStatusService;
            _roomImageService = roomImageService;
            _bookingService = bookingService;
        }

        public IActionResult Index()
        {
            ViewBag.Bookings = _bookingService.GetListByFilter(x => x.BookingTo.Date.AddDays(1) >= DateTime.Now.Date).Data;
            var model = new RoomListDto
            {
                Rooms = _roomService.GetList().Data,
                RoomTypes = _roomTypeService.GetList().Data,
                RoomStatuses = _roomStatusService.GetList().Data
            };

            return View(model);
        }
    }
}
