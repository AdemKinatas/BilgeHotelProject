using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RoomValidator : AbstractValidator<Room>
    {
        public RoomValidator()
        {
            RuleFor(x => x.RoomDescription).NotEmpty();
            RuleFor(x => x.RoomDescription).NotEmpty().Length(5,500);
            RuleFor(x => x.RoomFeatures).NotEmpty().Length(5, 500);
        }
    }
}
