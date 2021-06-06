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
    public class RoomTypeImageManager : IRoomTypeImageService
    {
        private readonly IRoomTypeImageDal _roomTypeImageDal;

        public RoomTypeImageManager(IRoomTypeImageDal roomTypeImageDal)
        {
            _roomTypeImageDal = roomTypeImageDal;
        }

        public IResult Add(RoomTypeImage entity)
        {
            _roomTypeImageDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(RoomTypeImage entity)
        {
            _roomTypeImageDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<RoomTypeImage> GetByFilter(Expression<Func<RoomTypeImage, bool>> filter)
        {
            return new SuccessDataResult<RoomTypeImage>(_roomTypeImageDal.Get(filter));
        }

        public IDataResult<RoomTypeImage> GetById(int id)
        {
            return new SuccessDataResult<RoomTypeImage>(_roomTypeImageDal.Get(x=>x.ID==id));
        }

        public IDataResult<List<RoomTypeImage>> GetList()
        {
            return new SuccessDataResult<List<RoomTypeImage>>(_roomTypeImageDal.GetAll());
        }

        public IDataResult<List<RoomTypeImage>> GetListByFilter(Expression<Func<RoomTypeImage, bool>> filter)
        {
            return new SuccessDataResult<List<RoomTypeImage>>(_roomTypeImageDal.GetAll(filter));
        }

        public IResult Update(RoomTypeImage entity)
        {
            _roomTypeImageDal.Update(entity);
            return new SuccessResult();
        }
    }
}
