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
    public class GuestManager : IGuestService
    {
        private readonly IGuestDal _guestDal;

        public GuestManager(IGuestDal customerDal)
        {
            _guestDal = customerDal;
        }

        public IResult Add(Guest entity)
        {
            _guestDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Guest entity)
        {
            _guestDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<Guest> GetByFilter(Expression<Func<Guest, bool>> filter)
        {
            return new SuccessDataResult<Guest>(_guestDal.Get(filter));
        }

        public IDataResult<Guest> GetById(int id)
        {
            return new SuccessDataResult<Guest>(_guestDal.Get(x=>x.ID==id));
        }

        public IDataResult<List<Guest>> GetList()
        {
            return new SuccessDataResult<List<Guest>>(_guestDal.GetAll());
        }

        public IDataResult<List<Guest>> GetListByFilter(Expression<Func<Guest, bool>> filter)
        {
            return new SuccessDataResult<List<Guest>>(_guestDal.GetAll(filter));
        }

        public IResult Update(Guest entity)
        {
            _guestDal.Update(entity);
            return new SuccessResult();
        }
    }
}
