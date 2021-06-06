using Business.Abstract;
using Business.Messages;
using Business.Utilities;
using Business.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class RoomManager : IRoomService
    {
        private readonly IRoomDal _roomDal;
        private readonly IRoomImageService _roomImageService;
        private readonly IRoomStatusService _roomStatusService;
        private readonly IBookingDal _bookingDal;

        public RoomManager(IRoomDal roomDal, IRoomImageService roomImageService, IRoomStatusService roomStatusService, IBookingDal bookingDal)
        {
            _roomDal = roomDal;
            _roomImageService = roomImageService;
            _roomStatusService = roomStatusService;
            _bookingDal = bookingDal;
        }

        public IResult Add(Room entity)
        {
            IResult result = BusinessRules.Run(CheckIfRoomNumberAlreadyExists(entity.RoomNumber));

            if (result != null)
            {
                return new ErrorResult(result.Message);
            }

            _roomDal.Add(entity);
            return new SuccessResult(RoomMessages.RoomAdded);
        }

        public IResult Delete(Room entity)
        {
            var result = BusinessRules.Run(DeleteRoomImages(entity.ID));

            if (result != null)
            {
                return result;
            }
            _roomDal.Delete(entity);

            return new SuccessResult();
        }

        public IDataResult<List<Room>> GetAllAvailableRooms()
        {
            var result = BusinessRules.Run(CheckAvailableRoomStatus());

            if (result != null)
            {
                return (IDataResult<List<Room>>)result;
            }

            var roomStatus = _roomStatusService.GetByFilter(x => x.RoomStatusName == "Müsait").Data;
            return new SuccessDataResult<List<Room>>(_roomDal.GetAll(x => x.RoomStatusId == roomStatus.ID));
        }

        public IDataResult<List<Room>> GetAvailableRoomsByRoomTypeId(int roomTypeId)
        {
            var result = BusinessRules.Run(CheckAvailableRoomStatus());

            if (result != null)
            {
                return (IDataResult<List<Room>>)result;
            }

            var roomStatus = _roomStatusService.GetByFilter(x => x.RoomStatusName == "Müsait").Data;
            return new SuccessDataResult<List<Room>>(_roomDal.GetAll(x => x.RoomStatusId == roomStatus.ID && x.RoomTypeId == roomTypeId));
        }

        public IDataResult<List<Room>> GetAvailableRoomsByFilter(BookingFilter bookingFilter)
        {
            var result = GetAvailableRoomsByFilters(bookingFilter);

            if (result != null)
            {
                return new ErrorDataResult<List<Room>>(result.Data, result.Message);
            }

            return new SuccessDataResult<List<Room>>(result.Data);
        }

        public IDataResult<Room> GetByFilter(Expression<Func<Room, bool>> filter)
        {
            return new SuccessDataResult<Room>(_roomDal.Get(filter));
        }

        public IDataResult<Room> GetById(int id)
        {
            return new SuccessDataResult<Room>(_roomDal.Get(x => x.ID == id));
        }

        public IDataResult<List<Room>> GetList()
        {
            var result = BusinessRules.Run(CheckAvailableRoomStatus());

            if (result != null)
            {
                return (IDataResult<List<Room>>)result;
            }

            return new SuccessDataResult<List<Room>>(_roomDal.GetAll());
        }

        public IDataResult<List<Room>> GetListByFilter(Expression<Func<Room, bool>> filter)
        {
            var result = BusinessRules.Run(CheckAvailableRoomStatus());

            if (result != null)
            {
                return (IDataResult<List<Room>>)result;
            }

            return new SuccessDataResult<List<Room>>(_roomDal.GetAll(filter));
        }

        public IResult Update(Room entity)
        {
            _roomDal.Update(entity);
            return new SuccessResult();
        }

        private IResult CheckIfRoomNumberAlreadyExists(int roomNumber)
        {
            var room = _roomDal.Get(x => x.RoomNumber == roomNumber);
            if (room != null)
            {
                return new ErrorResult(RoomMessages.RoomNumberAlreadyExist);
            }
            return new SuccessResult();
        }

        private IResult DeleteRoomImages(int id)
        {
            var imageList = _roomImageService.GetListByFilter(x => x.RoomId == id).Data;

            foreach (var image in imageList)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/Images/RoomImages/{image.ImageUrl}");
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }

            return new SuccessResult();
        }

        private IResult CheckAvailableRoomStatus()
        {
            var bookings = _bookingDal.GetAll(x => x.BookingTo >= DateTime.Now);
            var rooms = _roomDal.GetAll();
            foreach (var booking in bookings)
            {
                foreach (var room in rooms)
                {
                    if (room.ID == booking.RoomId)
                    {
                        if (booking.BookingFrom.Date <= DateTime.Now.Date && DateTime.Now.Date < booking.BookingTo)
                        {
                            room.RoomStatusId = _roomStatusService.GetByFilter(x => x.RoomStatusName == "Dolu").Data.ID;
                            _roomDal.Update(room);
                        }
                    }
                }
            }

            return new SuccessResult();
        }

        private IDataResult<List<Room>> GetAvailableRoomsByFilters(BookingFilter bookingFilter)
        {
            var bookings = _bookingDal.GetAll(x => x.BookingTo >= DateTime.Now);
            var rooms = _roomDal.GetAll(x => x.RoomTypeId == bookingFilter.RoomTypeId);
            var filteredRooms = new List<Room>();
            filteredRooms.AddRange(rooms);

            if (bookings.Count != 0)
            {
                foreach (var room in rooms)
                {
                    foreach (var booking in bookings)
                    {
                        if (booking.RoomId == room.ID)
                        {
                            if ((bookingFilter.BookingFrom >= booking.BookingFrom && bookingFilter.BookingFrom < booking.BookingTo) || (bookingFilter.BookingTo > booking.BookingFrom && bookingFilter.BookingTo <= booking.BookingTo))
                            {
                                if (filteredRooms.Contains(room))
                                {
                                    filteredRooms.Remove(room);
                                }
                            }
                        }
                    }
                }
            }

            if (filteredRooms.Count == 0)
            {
                return new ErrorDataResult<List<Room>>(filteredRooms, RoomMessages.NoRoomsFoundInYourCriteria);
            }
            return new SuccessDataResult<List<Room>>(filteredRooms);
        }
    }
}
