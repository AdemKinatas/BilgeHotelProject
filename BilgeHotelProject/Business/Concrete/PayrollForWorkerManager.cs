using Business.Abstract;
using Business.Utilities;
using Business.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class PayrollForWorkerManager : IPayrollForWorkerService
    {
        private readonly IPayrollForWorkerDal _payrollForWorkerDal;

        public PayrollForWorkerManager(IPayrollForWorkerDal payrollForWorkerDal)
        {
            _payrollForWorkerDal = payrollForWorkerDal;
        }

        public IResult Add(PayrollForWorker entity)
        {
            var result = BusinessRules.Run(CalculateWorkerSalary(entity));

            if (result != null)
            {
                return result;
            }

            _payrollForWorkerDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(PayrollForWorker entity)
        {
            _payrollForWorkerDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<PayrollForWorker> GetByFilter(Expression<Func<PayrollForWorker, bool>> filter)
        {
            return new SuccessDataResult<PayrollForWorker>(_payrollForWorkerDal.Get(filter));
        }

        public IDataResult<PayrollForWorker> GetById(int id)
        {
            return new SuccessDataResult<PayrollForWorker>(_payrollForWorkerDal.Get(x=> x.ID == id));
        }

        public IDataResult<List<PayrollForWorker>> GetList()
        {
            return new SuccessDataResult<List<PayrollForWorker>>(_payrollForWorkerDal.GetAll());
        }

        public IDataResult<List<PayrollForWorker>> GetListByFilter(Expression<Func<PayrollForWorker, bool>> filter)
        {
            return new SuccessDataResult<List<PayrollForWorker>>(_payrollForWorkerDal.GetAll(filter));
        }

        public IResult Update(PayrollForWorker entity)
        {
            var result = BusinessRules.Run(CalculateWorkerSalary(entity));

            if (result != null)
            {
                return result;
            }

            _payrollForWorkerDal.Update(entity);
            return new SuccessResult();
        }

        private IResult CalculateWorkerSalary(PayrollForWorker payrollForWorker)
        {
            payrollForWorker.Salary = (payrollForWorker.HourlyFee * payrollForWorker.DailyWorkingHours * payrollForWorker.TotalWorkingDaysPerMonth) + (payrollForWorker.Overtime * payrollForWorker.HourlyFee);
            return new SuccessResult();
        }
    }
}
