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
    public class WorkerController : Controller
    {
        private readonly IWorkerService _workerService;
        private readonly IDutyService _dutyService;

        public WorkerController(IWorkerService workerService, IDutyService dutyService)
        {
            _workerService = workerService;
            _dutyService = dutyService;
        }

        public IActionResult Index()
        {
            ViewBag.Duties = _dutyService.GetList().Data;
            var model = _workerService.GetList().Data;
            return View(model);
        }

        public IActionResult AddWorker()
        {
            ViewBag.Duties = new SelectList(_dutyService.GetList().Data, "ID", "DutyName");
            return View();
        }

        [HttpPost]
        public IActionResult AddWorker(Worker worker)
        {
            if (ModelState.IsValid)
            {
                var result = _workerService.Add(worker);
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }
            return View(worker);
        }

        public IActionResult UpdateWorker(int id)
        {
            var updated = _workerService.GetById(id).Data;
            ViewBag.Duties = new SelectList(_dutyService.GetList().Data, "ID", "DutyName",updated.DutyId);
            return View(updated);
        }

        [HttpPost]
        public IActionResult UpdateWorker(Worker worker)
        {
            if (ModelState.IsValid)
            {
                var result = _workerService.Update(worker);
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }
            return View(worker);
        }

        public IActionResult DeleteWorker(int id)
        {
            var deleted = _workerService.GetById(id).Data;
            return View(deleted);
        }

        [HttpPost]
        public IActionResult DeleteWorker(Worker worker)
        {
            try
            {
                var result = _workerService.Delete(worker);
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                    return View(worker);
                }
            }
            catch 
            {
                return View(worker);
            }
        }
    }
}
