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
    public class PaymentManager : IPaymentService
    {
        private readonly IPaymentDal _paymentDal;
        private readonly IBookingService _bookingService;

        public PaymentManager(IPaymentDal paymentDal, IBookingService bookingService)
        {
            _paymentDal = paymentDal;
            _bookingService = bookingService;
        }

        public IResult Add(Payment entity)
        {
            var result = BusinessRules.Run(CalculateTotalPayment(entity));

            if (result != null)
            {
                return result;
            }

            _paymentDal.Add(entity);

            var booking = _bookingService.GetById(entity.BookingId).Data;
            booking.IsPaid = true;
            _bookingService.Update(booking);
            return new SuccessResult();
        }

        public IResult Delete(Payment entity)
        {
            _paymentDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<Payment> GetByFilter(Expression<Func<Payment, bool>> filter)
        {
            return new SuccessDataResult<Payment>(_paymentDal.Get(filter));
        }

        public IDataResult<Payment> GetById(int id)
        {
            return new SuccessDataResult<Payment>(_paymentDal.Get(x=>x.ID==id));
        }

        public IDataResult<List<Payment>> GetList()
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll());
        }

        public IDataResult<List<Payment>> GetListByFilter(Expression<Func<Payment, bool>> filter)
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll(filter));
        }

        public IResult Update(Payment entity)
        {
            _paymentDal.Update(entity);
            return new SuccessResult();
        }

        private IResult CalculateTotalPayment(Payment payment)
        {
            var booking = _bookingService.GetById(payment.BookingId).Data;
            payment.PaymentAmount = booking.TotalAmount + payment.ExtraPrice;
            return new SuccessResult();
        }
    }
}
