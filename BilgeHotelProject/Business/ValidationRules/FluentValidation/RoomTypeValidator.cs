using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RoomTypeValidator : AbstractValidator<RoomType>
    {
        public RoomTypeValidator()
        {
            RuleFor(x => x.RoomTypeName).NotEmpty().MaximumLength(100);
        }
    }
}
