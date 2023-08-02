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
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator() 
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage(Messages.ProductNameCantEmpty);
            RuleFor(p => p.ProductName).MinimumLength(2).WithMessage(Messages.ProductNameHaveToMin2Character);
            RuleFor(p => p.UnitPrice).NotEmpty().WithMessage(Messages.UnitPriceCantEmpty);
            RuleFor(p => p.UnitPrice).GreaterThan(0).WithMessage(Messages.UnitPriceHaveToGreaterThanZero);
            RuleFor(p=>p.CategoryId).NotEmpty().WithMessage(Messages.CategoryCantEmpty);
        }
    }
}
