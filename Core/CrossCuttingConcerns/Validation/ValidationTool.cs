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
    //This Class Using Fluent But For Me
    public static class ValidationTool
    {
        
        public static void Validate(IValidator validator,object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                string errorMessage = GetJsonErrorMessage(result.Errors);
                LoggerTool.LoggerService(errorMessage, "", "");
                throw new ValidationException(errorMessage);
            }
        }
        private static string GetJsonErrorMessage(IList<ValidationFailure> errors)
        {
            var errorObjects = new List<object>();
            foreach (var error in errors)
            {
                var errorObject = new { PropertyName = error.PropertyName, ErrorMessage = error.ErrorMessage };
                errorObjects.Add(errorObject);
            }

            return JsonSerializer.Serialize(errorObjects, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
