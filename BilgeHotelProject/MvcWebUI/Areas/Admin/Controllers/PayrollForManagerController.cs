using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class PayrollForManagerController : Controller
    {
        private readonly IPayrollForManagerService _payrollForManagerService;
        private readonly IManagerService _managerService;

        public PayrollForManagerController(IPayrollForManagerService payrollForManagerService, IManagerService managerService)
        {
            _payrollForManagerService = payrollForManagerService;
            _managerService = managerService;
        }

        public IActionResult Index()
        {
            ViewBag.Managers = _managerService.GetList().Data;
            var model = _payrollForManagerService.GetList().Data;
            return View(model);
        }

        public IActionResult AddPayrollForManager()
        {
            ViewBag.Managers = new SelectList(_managerService.GetList().Data, "ID", "FullName");
            return View();
        }

        [HttpPost]
        public IActionResult AddPayrollForManager(PayrollForManager payrollForManager)
        {
            if (ModelState.IsValid)
            {
                var result = _payrollForManagerService.Add(payrollForManager);
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }
            return View(payrollForManager);
        }

        public IActionResult UpdatePayrollForManager(int id)
        {
            var updated = _payrollForManagerService.GetById(id).Data;
            ViewBag.Managers = new SelectList(_managerService.GetList().Data, "ID", "FullName", updated.ManagerId);
            return View(updated);
        }

        [HttpPost]
        public IActionResult UpdatePayrollForManager(PayrollForManager payrollForManager)
        {
            if (ModelState.IsValid)
            {
                var result = _payrollForManagerService.Update(payrollForManager);
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }
            return View(payrollForManager);
        }

        public IActionResult DeletePayrollForManager(int id)
        {
            var deleted = _payrollForManagerService.GetById(id).Data;

            return View(deleted);
        }

        [HttpPost]
        public IActionResult DeletePayrollForManager(PayrollForManager payrollForManager)
        {
            try
            {
                var result = _payrollForManagerService.Delete(payrollForManager);
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                    return View(payrollForManager);
                }
            }
            catch
            {
                return View(payrollForManager);
            }
        }
    }
}
