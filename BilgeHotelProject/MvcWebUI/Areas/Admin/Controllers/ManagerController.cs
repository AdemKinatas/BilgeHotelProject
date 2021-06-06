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
    public class ManagerController : Controller
    {
        private readonly IManagerService _managerService;
        private readonly IDutyService _dutyService;

        public ManagerController(IManagerService managerService, IDutyService dutyService)
        {
            _managerService = managerService;
            _dutyService = dutyService;
        }

        public IActionResult Index()
        {
            ViewBag.Duties = _dutyService.GetList().Data;
            var model = _managerService.GetList().Data;
            return View(model);
        }

        public IActionResult AddManager()
        {
            ViewBag.Duties = new SelectList(_dutyService.GetList().Data, "ID", "DutyName");
            return View();
        }

        [HttpPost]
        public IActionResult AddManager(Manager manager)
        {
            if (ModelState.IsValid)
            {
                var result = _managerService.Add(manager);
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }
            return View(manager);
        }

        public IActionResult UpdateManager(int id)
        {
            var updated = _managerService.GetById(id).Data;
            ViewBag.Duties = new SelectList(_dutyService.GetList().Data, "ID", "DutyName", updated.ID);
            return View(updated);
        }

        [HttpPost]
        public IActionResult UpdateManager(Manager manager)
        {
            if (ModelState.IsValid)
            {
                var result = _managerService.Update(manager);
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }
            return View(manager);
        }

        public IActionResult DeleteManager(int id)
        {
            var deleted = _managerService.GetById(id).Data;
            return View(deleted);
        }

        [HttpPost]
        public IActionResult DeleteManager(Manager manager)
        {
            try
            {
                var result = _managerService.Delete(manager);
                if (result.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                    return View(manager);
                }
            }
            catch
            {
                return View(manager);
            }
        }
    }
}
