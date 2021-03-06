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

namespace MvcWebUI.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IBookingPackageService _bookingPackageService;
        private readonly IRoomService _roomService;
        private readonly IRoomTypeService _roomTypeService;
        private readonly IRoomImageService _roomImageService;
        private readonly UserManager<AppUser> _userManager;

        public BookingController(IBookingService bookingService, IBookingPackageService bookingPackageService, IRoomService roomService, UserManager<AppUser> userManager, IRoomTypeService roomTypeService, IRoomImageService roomImageService)
        {
            _bookingService = bookingService;
            _bookingPackageService = bookingPackageService;
            _roomService = roomService;
            _userManager = userManager;
            _roomTypeService = roomTypeService;
            _roomImageService = roomImageService;
        }

        public IActionResult Index(Booking booking)
        {
            AppUser appUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
            booking.AppUserId = appUser.Id;
            var model = new BookingListDto
            {
                Bookings = _bookingService.GetListByFilter(x=>x.AppUserId == booking.AppUserId).Data,
                BookingPackages = _bookingPackageService.GetList().Data,
                Rooms = _roomService.GetList().Data
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult GetAvailableRooms(BookingFilter bookingFilter)
        {
            if (ModelState.IsValid)
            {
                bookingFilter.BookingFrom = bookingFilter.BookingFrom.AddHours(14);
                bookingFilter.BookingTo = bookingFilter.BookingTo.AddHours(10);

                var rooms = _roomService.GetAvailableRoomsByFilter(bookingFilter).Data;
                var room = rooms[0];
                ViewBag.Rooms = new SelectList(rooms, "ID", "RoomNumber", room.ID);
                ViewBag.BookingPackages = new SelectList(_bookingPackageService.GetList().Data, "ID", "BookingPackageName");

                ViewBag.RoomFilterListDto = new RoomFilterListDto
                {
                    Rooms = rooms,
                    RoomImages = _roomImageService.GetList().Data,
                    RoomType = _roomTypeService.GetById(bookingFilter.RoomTypeId).Data
                };

                Booking booking = new Booking { BookingFrom = bookingFilter.BookingFrom, BookingTo = bookingFilter.BookingTo, NoOfGuests = room.Capacity };
                return View(booking);
            }

            return RedirectToAction("Index","Home",bookingFilter);
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
                    return RedirectToAction("Index",booking);
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
