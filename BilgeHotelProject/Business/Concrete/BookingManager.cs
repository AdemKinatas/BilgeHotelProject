using Business.Abstract;
using Business.Messages;
using Business.Utilities;
using Business.Utilities.Results;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{

    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;
        private readonly IRoomService _roomService;
        private readonly IRoomStatusService _roomStatusService;
        private readonly IRoomTypeService _roomTypeService;
        private readonly IBookingPackageService _bookingPackageService;
        private readonly UserManager<AppUser> _userManager;

        public BookingManager(IBookingDal bookingDal, IRoomService roomService, IBookingPackageService bookingPackageService, IRoomStatusService roomStatusService, IRoomTypeService roomTypeService, UserManager<AppUser> userManager)
        {
            _bookingDal = bookingDal;
            _roomService = roomService;
            _roomStatusService = roomStatusService;
            _roomTypeService = roomTypeService;
            _bookingPackageService = bookingPackageService;
            _userManager = userManager;
        }

        public IResult Add(Booking entity)
        {
            var result = BusinessRules.Run(CalculateTotalAmount(entity),CheckAvailableStatusOfRoom(entity), ChangeRoomStatus(entity));

            if (result != null)
            {
                return new ErrorResult(result.Message);
            }

            _bookingDal.Add(entity);

            return new SuccessResult();
        }

        public IResult Delete(Booking entity)
        {
            var result = BusinessRules.Run(ChangeRoomStatusForDelete(entity));

            if (result != null)
            {
                return new ErrorResult(result.Message);
            }
            _bookingDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<Booking> GetByFilter(Expression<Func<Booking, bool>> filter)
        {
            return new SuccessDataResult<Booking>(_bookingDal.Get(filter));
        }

        public IDataResult<Booking> GetById(int id)
        {
            return new SuccessDataResult<Booking>(_bookingDal.Get(x => x.ID == id));
        }

        public IDataResult<List<Booking>> GetList()
        {
            return new SuccessDataResult<List<Booking>>(_bookingDal.GetAll());
        }

        public IDataResult<List<Booking>> GetListByFilter(Expression<Func<Booking, bool>> filter)
        {
            return new SuccessDataResult<List<Booking>>(_bookingDal.GetAll(filter));
        }

        public IResult Update(Booking entity)
        {
            var result = BusinessRules.Run(CalculateTotalAmount(entity), CheckAvailableStatusOfRoomForUpdate(entity), ChangeRoomStatusForUpdate(entity));

            if (result != null)
            {
                return new ErrorResult(result.Message);
            }

            _bookingDal.Update(entity);
            return new SuccessResult();
        }

        private IResult CalculateTotalAmount(Booking booking)
        {
            var room = _roomService.GetById(booking.RoomId).Data;
            var roomType = _roomTypeService.GetByFilter(x => x.ID == room.RoomTypeId).Data;
            var bookingPackage = _bookingPackageService.GetByFilter(x => x.BookingPackageName == "Her Şey Dahil").Data;
            AppUser user = _userManager.FindByIdAsync(Convert.ToString(booking.AppUserId)).Result;
            var result = _userManager.GetRolesAsync(user).Result;

            if (result.Contains("Member"))
            {
                if (booking.BookingFrom >= DateTime.Now.Date.AddDays(30) && booking.BookingFrom <= DateTime.Now.AddDays(90))
                {
                    if (booking.BookingPackageId == bookingPackage.ID)
                    {
                        booking.TotalAmount = (decimal)((booking.BookingTo - booking.BookingFrom).TotalDays) * roomType.BasePrice * 1.25m * 0.82m;
                    }
                    else
                    {
                        booking.TotalAmount = (decimal)((booking.BookingTo - booking.BookingFrom).TotalDays) * roomType.BasePrice * 0.84m;
                    }
                }
                else if(booking.BookingFrom > DateTime.Now.AddDays(90))
                {
                    if (booking.BookingPackageId == bookingPackage.ID)
                    {
                        booking.TotalAmount = (decimal)((booking.BookingTo - booking.BookingFrom).TotalDays) * roomType.BasePrice * 1.25m * 0.77m;
                    }
                    else
                    {
                        booking.TotalAmount = (decimal)((booking.BookingTo - booking.BookingFrom).TotalDays) * roomType.BasePrice * 0.77m;
                    }
                }
                else
                {
                    if (booking.BookingPackageId == bookingPackage.ID)
                    {
                        booking.TotalAmount = (decimal)((booking.BookingTo - booking.BookingFrom).TotalDays) * roomType.BasePrice * 1.25m;
                    }
                    else
                    {
                        booking.TotalAmount = (decimal)((booking.BookingTo - booking.BookingFrom).TotalDays) * roomType.BasePrice;
                    }
                }

            }
            else
            {
                if (booking.BookingPackageId == bookingPackage.ID)
                {
                    booking.TotalAmount = (decimal)((booking.BookingTo - booking.BookingFrom).TotalDays) * roomType.BasePrice * 1.25m;
                }
                else
                {
                    booking.TotalAmount = (decimal)((booking.BookingTo - booking.BookingFrom).TotalDays) * roomType.BasePrice;
                }
            }

            return new SuccessResult();
        }

        private IResult ChangeRoomStatus(Booking booking)
        {
            var room = _roomService.GetById(booking.RoomId).Data;
            if (booking.BookingFrom.Date <= DateTime.Now.Date && booking.BookingTo.Date > DateTime.Now.Date)
            {
                room.RoomStatusId = _roomStatusService.GetByFilter(x => x.RoomStatusName == "Dolu").Data.ID;
                _roomService.Update(room);
            }

            return new SuccessResult();
        }

        private IResult ChangeRoomStatusForUpdate(Booking booking)
        {
            var oldRoomId = _bookingDal.Get(x => x.ID == booking.ID).RoomId;
            if (oldRoomId != booking.RoomId)
            {
                if (booking.BookingFrom <= DateTime.Now && booking.BookingTo > DateTime.Now)
                {
                    var room = _roomService.GetById(booking.RoomId).Data;
                    var oldRoom = _roomService.GetById(oldRoomId).Data;
                    room.RoomStatusId = _roomStatusService.GetByFilter(x => x.RoomStatusName == "Dolu").Data.ID;
                    oldRoom.RoomStatusId = _roomStatusService.GetByFilter(x => x.RoomStatusName == "Müsait").Data.ID;
                    _roomService.Update(room);
                    _roomService.Update(oldRoom);
                }
            }
            return new SuccessResult();
        }

        private IResult ChangeRoomStatusForDelete(Booking booking)
        {
            var roomId = _bookingDal.Get(x => x.ID == booking.ID).RoomId;
            var room = _roomService.GetById(roomId).Data;

            room.RoomStatusId = _roomStatusService.GetByFilter(x => x.RoomStatusName == "Müsait").Data.ID;
            _roomService.Update(room);
            return new SuccessResult();
        }

        private IResult CheckAvailableStatusOfRoom(Booking booking)
        {
            var bookings = _bookingDal.GetAll(x => x.BookingTo >= DateTime.Now);
            foreach (var bookingAlready in bookings)
            {
                if (bookingAlready.RoomId == booking.RoomId)
                {
                    if ((booking.BookingFrom >= bookingAlready.BookingFrom && booking.BookingFrom < bookingAlready.BookingTo) || (booking.BookingTo > bookingAlready.BookingFrom && booking.BookingTo <= bookingAlready.BookingTo))
                    {
                        return new ErrorResult(BookingMessages.BusyDatesForBooking);
                    }
                }
            }
            return new SuccessResult();
        }

        private IResult CheckAvailableStatusOfRoomForUpdate(Booking booking)
        {
            var b = _bookingDal.Get(x => x.ID == booking.ID);
            var oldRoom = _roomService.GetById(b.RoomId).Data;
            var newRoom = _roomService.GetByFilter(x => x.ID == booking.RoomId).Data;
            var bookings = _bookingDal.GetAll(x => x.BookingTo >= DateTime.Now);
            foreach (var bookingAlready in bookings)
            {
                if (oldRoom.ID != newRoom.ID)
                {
                    if (bookingAlready.RoomId == booking.RoomId)
                    {
                        if ((booking.BookingFrom >= bookingAlready.BookingFrom && booking.BookingFrom < bookingAlready.BookingTo) || (booking.BookingTo > bookingAlready.BookingFrom && booking.BookingTo <= bookingAlready.BookingTo))
                        {
                            return new ErrorResult(BookingMessages.BusyDatesForBooking);
                        }
                    }
                }
            }
            return new SuccessResult();
        }
    }
}
