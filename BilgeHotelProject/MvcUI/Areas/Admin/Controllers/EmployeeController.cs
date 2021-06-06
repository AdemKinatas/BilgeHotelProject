using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDutyService _dutyService;

        public EmployeeController(IEmployeeService employeeService, IDutyService dutyService)
        {
            _employeeService = employeeService;
            _dutyService = dutyService;
        }

        public IActionResult Index()
        {
            var model = _employeeService.GetList().Data;
            return View(model);
        }

        public IActionResult AddEmployee()
        {
            ViewBag.Duties = new SelectList(_dutyService.GetList().Data, "Id", "DutyName");
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.Add(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public IActionResult UpdateEmployee(int id)
        {
            Employee employee = _employeeService.GetById(id).Data;

            ViewBag.Duties = new SelectList(_dutyService.GetList().Data, "Id", "DutyName",employee.DutyId);
            return View(employee);
        }

        [HttpPost]
        public IActionResult UpdateEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.Update(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public IActionResult DeleteEmployee(int id)
        {
            Employee employee = _employeeService.GetById(id).Data;

            return View(employee);
        }

        [HttpPost]
        public IActionResult DeleteEmployee(Employee employee)
        {
            try
            {
                _employeeService.Delete(employee);
                return RedirectToAction("Index");
            }
            catch 
            {
                return View();
            }
        }
    }
}
