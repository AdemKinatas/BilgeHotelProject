using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly IRoomTypeService _roomTypeService;
        private readonly IRoomImageService _roomImageService;

        public RoomController(IRoomService roomService, IRoomTypeService roomTypeService, IRoomImageService roomImageService)
        {
            _roomService = roomService;
            _roomTypeService = roomTypeService;
            _roomImageService = roomImageService;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult GetAvailableRooms(DateTime start,DateTime end,int quantity)
        {
            var model = new RoomFilterListVM
            {

            };
            return View(model);
        }
    }
}
