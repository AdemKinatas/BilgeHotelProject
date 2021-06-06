using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RoomStatusValidator:AbstractValidator<RoomStatus>
    {
        public RoomStatusValidator()
        {
            RuleFor(x => x.RoomStatusName).NotEmpty().MaximumLength(100);
        }
    }
}
