using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RoomImageValidator:AbstractValidator<RoomImage>
    {
        public RoomImageValidator()
        {
            RuleFor(x => x.ImageUrl).NotEmpty().MaximumLength(250);
        }
    }
}
