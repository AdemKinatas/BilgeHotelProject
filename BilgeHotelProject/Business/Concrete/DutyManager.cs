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
    public class DutyManager : IDutyService
    {
        private readonly IDutyDal _dutyDal;

        public DutyManager(IDutyDal dutyDal)
        {
            _dutyDal = dutyDal;
        }

        public IResult Add(Duty entity)
        {
            _dutyDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Duty entity)
        {
            _dutyDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<Duty> GetByFilter(Expression<Func<Duty, bool>> filter)
        {
            return new SuccessDataResult<Duty>(_dutyDal.Get(filter));
        }

        public IDataResult<Duty> GetById(int id)
        {
            return new SuccessDataResult<Duty>(_dutyDal.Get(x=>x.ID==id));
        }

        public IDataResult<List<Duty>> GetList()
        {
            return new SuccessDataResult<List<Duty>>(_dutyDal.GetAll());
        }

        public IDataResult<List<Duty>> GetListByFilter(Expression<Func<Duty, bool>> filter)
        {
            return new SuccessDataResult<List<Duty>>(_dutyDal.GetAll(filter));
        }

        public IResult Update(Duty entity)
        {
            _dutyDal.Update(entity);
            return new SuccessResult();
        }
    }
}
