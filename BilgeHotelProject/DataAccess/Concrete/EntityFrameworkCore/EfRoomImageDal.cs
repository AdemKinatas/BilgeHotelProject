using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameworkCore.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFrameworkCore
{
    public class EfRoomImageDal:EfEntityRepositoryBase<RoomImage>,IRoomImageDal
    {
    }
}
