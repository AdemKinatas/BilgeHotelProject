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
    public class DutyController : Controller
    {
        private readonly IDutyService _dutyService;

        public DutyController(IDutyService dutyService)
        {
            _dutyService = dutyService;
        }

        public IActionResult Index()
        {
            var model = _dutyService.GetList().Data;
            return View(model);
        }

        public IActionResult AddDuty()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDuty(Duty duty)
        {
            if (ModelState.IsValid)
            {
                _dutyService.Add(duty);
                return RedirectToAction("Index");
            }
            return View(duty);
        }

        public IActionResult UpdateDuty(int id)
        {
            Duty duty = _dutyService.GetById(id).Data;

            return View(duty);
        }

        [HttpPost]
        public IActionResult UpdateDuty(Duty duty)
        {
            if (ModelState.IsValid)
            {
                _dutyService.Update(duty);
                return RedirectToAction("Index");
            }
            return View(duty);
        }

        public IActionResult DeleteDuty(int id)
        {
            Duty duty = _dutyService.GetById(id).Data;

            return View(duty);
        }

        [HttpPost]
        public IActionResult DeleteDuty(Duty duty)
        {
            try
            {
                _dutyService.Delete(duty);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(duty);
            }
        }
    }
}
