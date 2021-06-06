using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;
        private readonly IRoomTypeService _roomTypeService;
        private readonly IRoomStatusService _roomStatusService;
        private readonly IRoomImageService _roomImageService;

        public RoomController(IRoomService roomService, IRoomTypeService roomTypeService, IRoomStatusService roomStatusService, IRoomImageService roomImageService)
        {
            _roomService = roomService;
            _roomTypeService = roomTypeService;
            _roomStatusService = roomStatusService;
            _roomImageService = roomImageService;
        }

        public IActionResult Index()
        {
            var model = new RoomListDto
            {
                Rooms = _roomService.GetList().Data,
                RoomTypes = _roomTypeService.GetList().Data,
                RoomStatuses = _roomStatusService.GetList().Data,
                RoomImages = _roomImageService.GetList().Data
            };
            
            return View(model);
        }

        public IActionResult AddRoom()
        {
            ViewBag.RoomTypes = new SelectList(_roomTypeService.GetList().Data, "ID", "RoomTypeName");
            ViewBag.RoomStatuses = new SelectList(_roomStatusService.GetList().Data, "ID", "RoomStatusName");
            return View();
        }

        [HttpPost]
        public IActionResult AddRoom(Room room,List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                var result = _roomService.Add(room);
                if (result.Success)
                {
                    if (files.Count != 0)
                    {
                        foreach (var file in files)
                        {
                            string imageExtension = Path.GetExtension(file.FileName);
                            string imageUrl = Guid.NewGuid() + imageExtension;
                            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/Images/RoomImages/{imageUrl}");
                            using var stream = new FileStream(path, FileMode.Create);
                            file.CopyTo(stream);
                            _roomImageService.Add(new RoomImage
                            {
                                ImageUrl = imageUrl,
                                RoomId = room.ID
                            });
                        }
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("",result.Message);
                }
            }
            return View(room);
        }

        public IActionResult UpdateRoom(int id)
        {
            var updated = _roomService.GetById(id).Data;
            ViewBag.RoomImages = _roomImageService.GetListByFilter(x => x.RoomId == id).Data;
            ViewBag.RoomTypes = new SelectList(_roomTypeService.GetList().Data, "ID", "RoomTypeName",updated.RoomTypeId);
            ViewBag.RoomStatuses = new SelectList(_roomStatusService.GetList().Data, "ID", "RoomStatusName",updated.RoomStatusId);
            return View(updated);
        }

        [HttpPost]
        public IActionResult UpdateRoom(Room room,List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                var result = _roomService.Update(room);

                if (result.Success)
                {
                    if (files.Count != 0)
                    {
                        var roomImageList = _roomImageService.GetListByFilter(x => x.RoomId == room.ID).Data;
                        foreach (var file in files)
                        {
                            string imageExtension = Path.GetExtension(file.FileName);
                            string imageUrl = Guid.NewGuid() + imageExtension;
                            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/Images/RoomImages/{imageUrl}");
                            using var stream = new FileStream(path, FileMode.Create);
                            file.CopyTo(stream);
                            _roomImageService.Add(new RoomImage
                            {
                                ImageUrl = imageUrl,
                                RoomId = room.ID
                            });
                        }

                        foreach (var roomImage in roomImageList)
                        {
                            if (System.IO.File.Exists($"wwwroot/Images/RoomImages/{roomImage.ImageUrl}"))
                            {
                                System.IO.File.Delete($"wwwroot/Images/RoomImages/{roomImage.ImageUrl}");
                            }
                            _roomImageService.Delete(roomImage);
                        }
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }
            return View(room);
        }

        public IActionResult DeleteRoom(int id)
        {
            var deleted = _roomService.GetById(id).Data;
            return View(deleted);
        }

        [HttpPost]
        public IActionResult DeleteRoom(Room room)
        {
            try
            {
                var roomImageList = _roomImageService.GetListByFilter(x => x.RoomId == room.ID).Data;
                foreach (var roomImage in roomImageList)
                {
                    if (System.IO.File.Exists($"wwwroot/Images/RoomImages/{roomImage.ImageUrl}"))
                    {
                        System.IO.File.Delete($"wwwroot/Images/RoomImages/{roomImage.ImageUrl}");
                    }
                    _roomImageService.Delete(roomImage);
                }
                _roomService.Delete(room);
                return RedirectToAction("Index");
            }
            catch 
            {
                return View(room);
            }
        }
    }
}
