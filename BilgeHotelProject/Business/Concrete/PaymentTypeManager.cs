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
    public class PaymentTypeManager : IPaymentTypeService
    {
        private readonly IPaymentTypeDal _paymentTypeDal;

        public PaymentTypeManager(IPaymentTypeDal paymentTypeDal)
        {
            _paymentTypeDal = paymentTypeDal;
        }

        public IResult Add(PaymentType entity)
        {
            _paymentTypeDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(PaymentType entity)
        {
            _paymentTypeDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<PaymentType> GetByFilter(Expression<Func<PaymentType, bool>> filter)
        {
            return new SuccessDataResult<PaymentType>(_paymentTypeDal.Get(filter));
        }

        public IDataResult<PaymentType> GetById(int id)
        {
            return new SuccessDataResult<PaymentType>(_paymentTypeDal.Get(x=>x.ID==id));
        }

        public IDataResult<List<PaymentType>> GetList()
        {
            return new SuccessDataResult<List<PaymentType>>(_paymentTypeDal.GetAll());
        }

        public IDataResult<List<PaymentType>> GetListByFilter(Expression<Func<PaymentType, bool>> filter)
        {
            return new SuccessDataResult<List<PaymentType>>(_paymentTypeDal.GetAll(filter));
        }

        public IResult Update(PaymentType entity)
        {
            _paymentTypeDal.Update(entity);
            return new SuccessResult();
        }
    }
}
