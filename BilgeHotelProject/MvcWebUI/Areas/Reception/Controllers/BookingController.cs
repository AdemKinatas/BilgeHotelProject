using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IBookingPackageService _bookingPackageService;
        private readonly IRoomService _roomService;
        private readonly IRoomTypeService _roomTypeService;
        private readonly UserManager<AppUser> _userManager;

        public BookingController(IBookingService bookingService, IBookingPackageService bookingPackageService, IRoomService roomService, UserManager<AppUser> userManager, IRoomTypeService roomTypeService)
        {
            _bookingService = bookingService;
            _bookingPackageService = bookingPackageService;
            _roomService = roomService;
            _userManager = userManager;
            _roomTypeService = roomTypeService;
        }

        public IActionResult Index()
        {
            var model = new BookingListDto
            {
                Bookings = _bookingService.GetList().Data,
                BookingPackages = _bookingPackageService.GetList().Data,
                Rooms = _roomService.GetList().Data
            };
            return View(model);
        }

        public IActionResult GetAvailableRoomsByFilter()
        {
            ViewBag.RoomTypes = new SelectList(_roomTypeService.GetList().Data, "ID", "RoomTypeName");
            return View();
        }

        [HttpPost]
        public IActionResult GetAvailableRoomsByFilter(BookingFilter bookingFilter)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("AddBooking", bookingFilter);
            }
            return View();
        }

        public IActionResult AddBooking(BookingFilter bookingFilter)
        {
            var rooms = _roomService.GetAvailableRoomsByFilter(bookingFilter).Data;
            var room = rooms[0];
            ViewBag.Rooms = new SelectList(rooms, "ID", "RoomNumber", room.ID);
            ViewBag.BookingPackages = new SelectList(_bookingPackageService.GetList().Data, "ID", "BookingPackageName");

            var booking = new Booking { BookingFrom = bookingFilter.BookingFrom, BookingTo = bookingFilter.BookingTo, NoOfGuests = room.Capacity };

            bookingFilter.BookingFrom = bookingFilter.BookingFrom.AddHours(14);
            bookingFilter.BookingTo = bookingFilter.BookingTo.AddHours(10);

            return View(booking);
        }

        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            if (ModelState.IsValid)
            {
                GetAppUser(booking);

                var result = _bookingService.Add(booking);

                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }
            return View(booking);
        }

        public IActionResult UpdateBooking(int id)
        {
            var updated = _bookingService.GetById(id).Data;
            var availableRoomsList = _roomService.GetAllAvailableRooms().Data;
            var room = _roomService.GetByFilter(x => x.ID == updated.RoomId).Data;
            availableRoomsList.Add(room);
            ViewBag.Rooms = new SelectList(availableRoomsList, "ID", "RoomNumber", updated.RoomId);
            ViewBag.BookingPackages = new SelectList(_bookingPackageService.GetList().Data, "ID", "BookingPackageName", updated.BookingPackageId);

            return View(updated);
        }

        [HttpPost]
        public IActionResult UpdateBooking(Booking booking)
        {
            if (ModelState.IsValid)
            {
                GetAppUser(booking);

                var result = _bookingService.Update(booking);

                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }
            return View(booking);
        }

        public IActionResult DeleteBooking(int id)
        {
            var deleted = _bookingService.GetById(id).Data;
            return View(deleted);
        }

        [HttpPost]
        public IActionResult DeleteBooking(Booking booking)
        {
            try
            {
                _bookingService.Delete(booking);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(booking);
            }
        }

        private void GetAppUser(Booking booking)
        {
            AppUser appUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
            booking.AppUserId = appUser.Id;
        }
    }
}
