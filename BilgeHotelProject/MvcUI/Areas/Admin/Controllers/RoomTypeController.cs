using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomTypeController : Controller
    {
        private readonly IRoomTypeService _roomTypeService;
        private readonly IRoomTypeImageService _roomTypeImageService;

        public RoomTypeController(IRoomTypeService roomTypeService, IRoomTypeImageService roomTypeImageService)
        {
            _roomTypeService = roomTypeService;
            _roomTypeImageService = roomTypeImageService;
        }

        public IActionResult Index()
        {
            ViewBag.Images = _roomTypeImageService.GetList().Data;
            var model = _roomTypeService.GetList().Data;
            return View(model);
        }

        public IActionResult AddRoomType()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRoomType(RoomType roomType, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                _roomTypeService.Add(roomType);

                if (files.Count != 0)
                {
                    foreach (var file in files)
                    {
                        string imageExtension = Path.GetExtension(file.FileName);
                        string imageUrl = Guid.NewGuid() + imageExtension;
                        string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/Images/RoomTypeImages/{imageUrl}");
                        using var stream = new FileStream(path, FileMode.Create);
                        file.CopyTo(stream);
                        _roomTypeImageService.Add(new RoomTypeImage
                        {
                            ImageUrl = imageUrl,
                            RoomTypeId = roomType.ID
                        });
                    }
                }
                return RedirectToAction("Index");
            }
            return View(roomType);
        }

        public IActionResult UpdateRoomType(int id)
        {
            var updated = _roomTypeService.GetById(id).Data;
            ViewBag.RoomTypeImages = _roomTypeImageService.GetListByFilter(x => x.RoomTypeId == id).Data;
            return View(updated);
        }

        [HttpPost]
        public IActionResult UpdateRoomType(RoomType roomType, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                _roomTypeService.Update(roomType);
                if (files.Count != 0)
                {
                    var roomTypeImageList = _roomTypeImageService.GetListByFilter(x=>x.RoomTypeId == roomType.ID).Data;
                    foreach (var file in files)
                    {
                        string imageExtension = Path.GetExtension(file.FileName);
                        string imageUrl = Guid.NewGuid() + imageExtension;
                        string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/Images/RoomTypeImages/{imageUrl}");
                        using var stream = new FileStream(path, FileMode.Create);
                        file.CopyTo(stream);
                        _roomTypeImageService.Add(new RoomTypeImage
                        {
                            ImageUrl = imageUrl,
                            RoomTypeId = roomType.ID
                        });
                    }
                    foreach (var roomTypeImage in roomTypeImageList)
                    {
                        if (System.IO.File.Exists($"wwwroot/Images/RoomTypeImages/{roomTypeImage.ImageUrl}"))
                        {
                            System.IO.File.Delete($"wwwroot/Images/RoomTypeImages/{roomTypeImage.ImageUrl}");
                        }
                        _roomTypeImageService.Delete(roomTypeImage);
                    }
                }
                return RedirectToAction("Index");
            }
            return View(roomType);
        }

        public IActionResult DeleteRoomType(int id)
        {
            var deleted = _roomTypeService.GetById(id).Data;
            return View(deleted);
        }

        [HttpPost]
        public IActionResult DeleteRoomType(RoomType roomType)
        {
            try
            {
                var roomTypeImageList = _roomTypeImageService.GetListByFilter(x => x.RoomTypeId == roomType.ID).Data;
                foreach (var roomTypeImage in roomTypeImageList)
                {
                    if (System.IO.File.Exists($"wwwroot/Images/RoomTypeImages/{roomTypeImage.ImageUrl}"))
                    {
                        System.IO.File.Delete($"wwwroot/Images/RoomTypeImages/{roomTypeImage.ImageUrl}");
                    }
                    _roomTypeImageService.Delete(roomTypeImage);
                }
                _roomTypeService.Delete(roomType);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(roomType);
            }
        }
    }
}
