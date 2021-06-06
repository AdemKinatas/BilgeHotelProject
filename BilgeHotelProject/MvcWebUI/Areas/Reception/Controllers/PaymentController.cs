using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IBookingService _bookingService;
        private readonly IPaymentTypeService _paymentTypeService;
        private readonly IBookingPackageService _bookingPackageService;

        public PaymentController(IPaymentService paymentService, IBookingService bookingService, IPaymentTypeService paymentTypeService, IBookingPackageService bookingPackageService)
        {
            _paymentService = paymentService;
            _bookingService = bookingService;
            _paymentTypeService = paymentTypeService;
            _bookingPackageService = bookingPackageService;
        }

        public IActionResult Index()
        {
            var model = new PaymentListDto
            {
                Payments = _paymentService.GetList().Data,
                PaymentTypes = _paymentTypeService.GetList().Data,
                Bookings = _bookingService.GetList().Data
            };
            return View(model);
        }

        public IActionResult AddPayment(int bookingId)
        {
            var booking = _bookingService.GetById(bookingId).Data;
            TempData["booking"] = booking;
            TempData["bookingPackage"] = _bookingPackageService.GetById(booking.BookingPackageId).Data;
            ViewBag.PaymentTypes = new SelectList(_paymentTypeService.GetList().Data, "ID", "PaymentTypeName");
            Payment payment = new Payment { BookingId = bookingId };
            return View(payment);
        }

        [HttpPost]
        public IActionResult AddPayment(Payment payment)
        {
            if (ModelState.IsValid)
            {
                var result = _paymentService.Add(payment);
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }
            return View(payment);
        }

        public IActionResult UpdatePayment(int id)
        {
            var updated = _paymentService.GetById(id).Data;
            return View(updated);
        }

        [HttpPost]
        public IActionResult UpdatePayment(Payment payment)
        {
            if (ModelState.IsValid)
            {
                var result = _paymentService.Update(payment);
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }
            return View(payment);
        }

        public IActionResult DeletePayment(int id)
        {
            var deleted = _paymentService.GetById(id).Data;
            return View(deleted);
        }

        [HttpPost]
        public IActionResult DeletePayment(Payment payment)
        {
            try
            {
                var result = _paymentService.Update(payment);
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                    return View(payment);
                }
            }
            catch
            {
                return View(payment);
            }
        }
    }
}
