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
    public class RoomStatusManager : IRoomStatusService
    {
        private readonly IRoomStatusDal _roomStatusDal;

        public RoomStatusManager(IRoomStatusDal roomStatusDal)
        {
            _roomStatusDal = roomStatusDal;
        }

        public IResult Add(RoomStatus entity)
        {
            _roomStatusDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(RoomStatus entity)
        {
            _roomStatusDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<RoomStatus> GetByFilter(Expression<Func<RoomStatus, bool>> filter)
        {
            return new SuccessDataResult<RoomStatus>(_roomStatusDal.Get(filter));
        }

        public IDataResult<RoomStatus> GetById(int id)
        {
            return new SuccessDataResult<RoomStatus>(_roomStatusDal.Get(x=>x.ID==id));
        }

        public IDataResult<List<RoomStatus>> GetList()
        {
            return new SuccessDataResult<List<RoomStatus>>(_roomStatusDal.GetAll());
        }

        public IDataResult<List<RoomStatus>> GetListByFilter(Expression<Func<RoomStatus, bool>> filter)
        {
            return new SuccessDataResult<List<RoomStatus>>(_roomStatusDal.GetAll(filter));
        }

        public IResult Update(RoomStatus entity)
        {
            _roomStatusDal.Update(entity);
            return new SuccessResult();
        }
    }
}
