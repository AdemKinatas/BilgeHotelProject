using Business.Abstract;
using Business.Utilities.Results;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class RoomImageManager : IRoomImageService
    {
        private readonly IRoomImageDal _roomImageDal;

        public RoomImageManager(IRoomImageDal roomImageDal)
        {
            _roomImageDal = roomImageDal;
        }

        public IResult Add(RoomImage entity)
        {
            _roomImageDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(RoomImage entity)
        {
            _roomImageDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<RoomImage> GetByFilter(Expression<Func<RoomImage, bool>> filter)
        {
            return new SuccessDataResult<RoomImage>(_roomImageDal.Get(filter));
        }

        public IDataResult<RoomImage> GetById(int id)
        {
            return new SuccessDataResult<RoomImage>(_roomImageDal.Get(x=>x.ID==id));
        }

        public IDataResult<List<RoomImage>> GetList()
        {
            return new SuccessDataResult<List<RoomImage>>(_roomImageDal.GetAll());
        }

        public IDataResult<List<RoomImage>> GetListByFilter(Expression<Func<RoomImage, bool>> filter)
        {
            return new SuccessDataResult<List<RoomImage>>(_roomImageDal.GetAll(filter));
        }

        public IResult Update(RoomImage entity)
        {
            _roomImageDal.Update(entity);
            return new SuccessResult();
        }
    }
}
