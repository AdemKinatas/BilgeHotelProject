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
    public class WorkerManager : IWorkerService
    {
        private readonly IWorkerDal _workerDal;

        public WorkerManager(IWorkerDal workerDal)
        {
            _workerDal = workerDal;
        }

        public IResult Add(Worker entity)
        {
            string fullName = entity.FirstName + " " + entity.LastName;
            entity.FullName = fullName;
            _workerDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Worker entity)
        {
            _workerDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<Worker> GetByFilter(Expression<Func<Worker, bool>> filter)
        {
            return new SuccessDataResult<Worker>(_workerDal.Get(filter));
        }

        public IDataResult<Worker> GetById(int id)
        {
            return new SuccessDataResult<Worker>(_workerDal.Get(x=>x.ID == id));
        }

        public IDataResult<List<Worker>> GetList()
        {
            return new SuccessDataResult<List<Worker>>(_workerDal.GetAll());
        }

        public IDataResult<List<Worker>> GetListByFilter(Expression<Func<Worker, bool>> filter)
        {
            return new SuccessDataResult<List<Worker>>(_workerDal.GetAll(filter));
        }

        public IResult Update(Worker entity)
        {
            string fullName = entity.FirstName + " " + entity.LastName;
            entity.FullName = fullName;
            _workerDal.Update(entity);
            return new SuccessResult();
        }
    }
}
