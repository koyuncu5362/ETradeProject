using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class FavouriteValidator:AbstractValidator<Favourite>
    {
        public FavouriteValidator()
        {
            RuleFor(f=>f.ProductId).NotEmpty().WithMessage(Messages.ProductIdCantEmpty);
            RuleFor(f=>f.CustomerId).NotEmpty().WithMessage(Messages.CustomerIdCantEmpty);
                        
        }
    }
}
