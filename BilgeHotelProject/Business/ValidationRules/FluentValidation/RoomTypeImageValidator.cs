using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RoomTypeImageValidator : AbstractValidator<RoomTypeImage>
    {
        public RoomTypeImageValidator()
        {
            RuleFor(x => x.ImageUrl).NotEmpty().MaximumLength(250);
        }
    }
}
