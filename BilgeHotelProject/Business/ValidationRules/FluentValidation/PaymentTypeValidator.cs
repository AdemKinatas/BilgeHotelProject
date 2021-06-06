using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class PaymentTypeValidator:AbstractValidator<PaymentType>
    {
        public PaymentTypeValidator()
        {
            RuleFor(x => x.PaymentTypeName).NotEmpty().MaximumLength(100);
        }
    }
}
