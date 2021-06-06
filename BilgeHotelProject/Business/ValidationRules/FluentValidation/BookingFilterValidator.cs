using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BookingFilterValidator:AbstractValidator<BookingFilter>
    {
        public BookingFilterValidator()
        {
            RuleFor(x => x.BookingFrom.Date).GreaterThanOrEqualTo(DateTime.Now.Date);
            RuleFor(x => x.BookingTo.Date).GreaterThan(x => x.BookingFrom.Date);
        }
    }
}
