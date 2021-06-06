using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameworkCore.Context;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFrameworkCore
{
    public class EfBookingDal : EfEntityRepositoryBase<Booking>, IBookingDal
    {
    }
}

