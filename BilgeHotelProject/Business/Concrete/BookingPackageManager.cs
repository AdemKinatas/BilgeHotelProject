using Business.Abstract;
using Business.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class BookingPackageManager : IBookingPackageService
    {
        private readonly IBookingPackageDal _bookingPackageDal;

        public BookingPackageManager(IBookingPackageDal bookingPackageDal)
        {
            _bookingPackageDal = bookingPackageDal;
        }

        public IResult Add(BookingPackage entity)
        {
            _bookingPackageDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(BookingPackage entity)
        {
            _bookingPackageDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<BookingPackage> GetByFilter(Expression<Func<BookingPackage, bool>> filter)
        {
            return new SuccessDataResult<BookingPackage>(_bookingPackageDal.Get(filter));
        }

        public IDataResult<BookingPackage> GetById(int id)
        {
            return new SuccessDataResult<BookingPackage>(_bookingPackageDal.Get(x=>x.ID==id));
        }

        public IDataResult<List<BookingPackage>> GetList()
        {
            return new SuccessDataResult<List<BookingPackage>>(_bookingPackageDal.GetAll());
        }

        public IDataResult<List<BookingPackage>> GetListByFilter(Expression<Func<BookingPackage, bool>> filter)
        {
            return new SuccessDataResult<List<BookingPackage>>(_bookingPackageDal.GetAll(filter));
        }

        public IResult Update(BookingPackage entity)
        {
            _bookingPackageDal.Update(entity);
            return new SuccessResult();
        }
    }
}
