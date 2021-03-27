using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator<CarImage>
    {

        public CarImageValidator()
        {
            RuleFor(c => c.CarId).NotEmpty();
        }
    }
}
