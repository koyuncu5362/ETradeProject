using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logger;
using Core.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Http;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {

        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                LoggerTool.LoggerService(result.Errors[0].ErrorMessage.ToString(), "", "");
                throw new ValidationException(result.Errors[0].ErrorMessage);
            }
        }
    }
}
