using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BookingPackageValidator:AbstractValidator<BookingPackage>
    {
        public BookingPackageValidator()
        {
            RuleFor(x => x.BookingPackageName).NotEmpty().MaximumLength(100);
        }
    }
}
