using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Areas.HumanResources.Controllers
{
    [Authorize(Roles = "Admin,HumanResources")]
    [Area("HumanResources")]
    public class PayrollForWorkerController : Controller
    {
        private readonly IPayrollForWorkerService _payrollForWorkerService;
        private readonly IWorkerService _workerService;

        public PayrollForWorkerController(IPayrollForWorkerService payrollForWorkerService, IWorkerService workerService)
        {
            _payrollForWorkerService = payrollForWorkerService;
            _workerService = workerService;
        }

        public IActionResult Index()
        {
            ViewBag.Workers = _workerService.GetList().Data;
            var model = _payrollForWorkerService.GetList().Data;
            return View(model);
        }

        public IActionResult AddPayrollForWorker()
        {
            ViewBag.Workers = new SelectList(_workerService.GetList().Data, "ID", "FullName");
            return View();
        }

        [HttpPost]
        public IActionResult AddPayrollForWorker(PayrollForWorker payrollForWorker)
        {
            if (ModelState.IsValid)
            {
                var result = _payrollForWorkerService.Add(payrollForWorker);
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }
            return View(payrollForWorker);
        }

        public IActionResult UpdatePayrollForWorker(int id)
        {
            var updated = _payrollForWorkerService.GetById(id).Data;
            ViewBag.Workers = new SelectList(_workerService.GetList().Data, "ID", "FullName", updated.WorkerId);
            return View(updated);
        }

        [HttpPost]
        public IActionResult UpdatePayrollForWorker(PayrollForWorker payrollForWorker)
        {
            if (ModelState.IsValid)
            {
                var result = _payrollForWorkerService.Update(payrollForWorker);
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }
            return View(payrollForWorker);
        }

        public IActionResult DeletePayrollForWorker(int id)
        {
            var deleted = _payrollForWorkerService.GetById(id).Data;

            return View(deleted);
        }

        [HttpPost]
        public IActionResult DeletePayrollForWorker(PayrollForWorker payrollForWorker)
        {
            try
            {
                var result = _payrollForWorkerService.Delete(payrollForWorker);
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                    return View(payrollForWorker);
                }
            }
            catch
            {
                return View(payrollForWorker);
            }
        }
    }
}
