using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcUI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRoomTypeService _roomTypeService;
        private readonly IRoomTypeImageService _roomTypeImageService;

        public HomeController(IRoomTypeService roomTypeService, IRoomTypeImageService roomTypeImageService)
        {
            _roomTypeService = roomTypeService;
            _roomTypeImageService = roomTypeImageService;
        }

        public IActionResult Index()
        {
            ViewBag.FilterModel = new SearchFilterModel();
            var model = new RoomTypeDetailListDto
            {
                RoomTypes = _roomTypeService.GetList().Data,
                RoomTypeImages = _roomTypeImageService.GetList().Data
            };
            return View(model);
        }
    }
}
