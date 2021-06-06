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
    public class RoomTypeManager : IRoomTypeService
    {
        private readonly IRoomTypeDal _roomTypeDal;

        public RoomTypeManager(IRoomTypeDal roomTypeDal)
        {
            _roomTypeDal = roomTypeDal;
        }

        public IResult Add(RoomType entity)
        {
            _roomTypeDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(RoomType entity)
        {
            _roomTypeDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<RoomType> GetByFilter(Expression<Func<RoomType, bool>> filter)
        {
            return new SuccessDataResult<RoomType>(_roomTypeDal.Get(filter));
        }

        public IDataResult<RoomType> GetById(int id)
        {
            return new SuccessDataResult<RoomType>(_roomTypeDal.Get(x=>x.ID==id));
        }

        public IDataResult<List<RoomType>> GetList()
        {
            return new SuccessDataResult<List<RoomType>>(_roomTypeDal.GetAll());
        }

        public IDataResult<List<RoomType>> GetListByFilter(Expression<Func<RoomType, bool>> filter)
        {
            return new SuccessDataResult<List<RoomType>>(_roomTypeDal.GetAll(filter));
        }

        public IResult Update(RoomType entity)
        {
            _roomTypeDal.Update(entity);
            return new SuccessResult();
        }
    }
}
