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
    public class PaymentTypeController : Controller
    {
        private readonly IPaymentTypeService _paymentTypeService;

        public PaymentTypeController(IPaymentTypeService paymentTypeService)
        {
            _paymentTypeService = paymentTypeService;
        }

        public IActionResult Index()
        {
            var model = _paymentTypeService.GetList().Data;
         
            return View(model);
        }

        public IActionResult AddPaymentType()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPaymentType(PaymentType paymentType)
        {
            if (ModelState.IsValid)
            {
                _paymentTypeService.Add(paymentType);
                return RedirectToAction("Index");
            }
            return View(paymentType);
        }

        public IActionResult UpdatePaymentType(int id)
        {
            var updated = _paymentTypeService.GetById(id).Data;
            return View(updated);
        }

        [HttpPost]
        public IActionResult UpdatePaymentType(PaymentType paymentType)
        {
            if (ModelState.IsValid)
            {
                _paymentTypeService.Update(paymentType);
                return RedirectToAction("Index");
            }
            return View(paymentType);
        }

        public IActionResult DeletePaymentType(int id)
        {
            var deleted = _paymentTypeService.GetById(id).Data;

            return View(deleted);
        }

        [HttpPost]
        public IActionResult DeletePaymentType(PaymentType paymentType)
        {
            try
            {
                _paymentTypeService.Delete(paymentType);
                return RedirectToAction("Index");
            }
            catch 
            {
                return View(paymentType);
            }
        }
    }
}
