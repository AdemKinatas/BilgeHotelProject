using Business.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRoomService:IGenericService<Room>
    {
        IDataResult<List<Room>> GetAllAvailableRooms();
        IDataResult<List<Room>> GetAvailableRoomsByRoomTypeId(int roomTypeId);
        IDataResult<List<Room>> GetAvailableRoomsByFilter(BookingFilter bookingFilter);
    }
}
