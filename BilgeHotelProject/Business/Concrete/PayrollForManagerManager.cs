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
    public class PayrollForManagerManager : IPayrollForManagerService
    {
        private readonly IPayrollForManagerDal _payrollForManagerDal;

        public PayrollForManagerManager(IPayrollForManagerDal payrollForManagerDal)
        {
            _payrollForManagerDal = payrollForManagerDal;
        }

        public IResult Add(PayrollForManager entity)
        {
            _payrollForManagerDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(PayrollForManager entity)
        {
            _payrollForManagerDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<PayrollForManager> GetByFilter(Expression<Func<PayrollForManager, bool>> filter)
        {
            return new SuccessDataResult<PayrollForManager>(_payrollForManagerDal.Get(filter));
        }

        public IDataResult<PayrollForManager> GetById(int id)
        {
            return new SuccessDataResult<PayrollForManager>(_payrollForManagerDal.Get(x=>x.ID == id));
        }

        public IDataResult<List<PayrollForManager>> GetList()
        {
            return new SuccessDataResult<List<PayrollForManager>>(_payrollForManagerDal.GetAll());
        }

        public IDataResult<List<PayrollForManager>> GetListByFilter(Expression<Func<PayrollForManager, bool>> filter)
        {
            return new SuccessDataResult<List<PayrollForManager>>(_payrollForManagerDal.GetAll(filter));
        }

        public IResult Update(PayrollForManager entity)
        {
            _payrollForManagerDal.Update(entity);
            return new SuccessResult();
        }
    }
}
