using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BookingValidator:AbstractValidator<Booking>
    {
        public BookingValidator()
        {
            RuleFor(x => x.PersonName).NotEmpty().Length(2,100);
            RuleFor(x => x.PersonLastName).NotEmpty().Length(2, 100);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(100);
            RuleFor(x => x.PhoneNumber).NotEmpty().Length(9,13);
            RuleFor(x => x.BookingFrom.Date).GreaterThanOrEqualTo(DateTime.Now.Date);
            RuleFor(x => x.BookingTo.Date).GreaterThan(x => x.BookingFrom.Date);
        }
    }
}
