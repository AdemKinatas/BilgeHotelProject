using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IRoomTypeImageService _roomTypeImageService;

        public RoomController(IRoomService roomService, IRoomTypeService roomTypeService, IRoomTypeImageService roomTypeImageService)
        {
            _roomService = roomService;
            _roomTypeService = roomTypeService;
            _roomTypeImageService = roomTypeImageService;
        }

        public IActionResult Index()
        {
            var model = new RoomTypeDetailListDto
            {
                RoomTypes = _roomTypeService.GetList().Data,
                RoomTypeImages = _roomTypeImageService.GetList().Data
            };
            return View(model);
        }
    }
}
