using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameworkCore.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFrameworkCore
{
    public class EfRoomDal:EfEntityRepositoryBase<Room>,IRoomDal
    {

    }
}
