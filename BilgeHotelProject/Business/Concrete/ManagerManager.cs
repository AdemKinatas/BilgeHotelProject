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
    public class ManagerManager : IManagerService
    {
        private readonly IManagerDal _managerDal;

        public ManagerManager(IManagerDal managerDal)
        {
            _managerDal = managerDal;
        }

        public IResult Add(Manager entity)
        {
            string fullName = entity.FirstName + " " + entity.LastName;
            entity.FullName = fullName;
            _managerDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Manager entity)
        {
            _managerDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<Manager> GetByFilter(Expression<Func<Manager, bool>> filter)
        {
            return new SuccessDataResult<Manager>(_managerDal.Get(filter));
        }

        public IDataResult<Manager> GetById(int id)
        {
            return new SuccessDataResult<Manager>(_managerDal.Get(x=>x.ID == id));
        }

        public IDataResult<List<Manager>> GetList()
        {
            return new SuccessDataResult<List<Manager>>(_managerDal.GetAll());
        }

        public IDataResult<List<Manager>> GetListByFilter(Expression<Func<Manager, bool>> filter)
        {
            return new SuccessDataResult<List<Manager>>(_managerDal.GetAll());
        }

        public IResult Update(Manager entity)
        {
            string fullName = entity.FirstName + " " + entity.LastName;
            entity.FullName = fullName;
            _managerDal.Update(entity);
            return new SuccessResult();
        }
    }
}
