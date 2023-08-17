using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductImageService
    {
        IResult Add(ProductImageModel productImage);
        IResult Delete(ProductImageModel productImage);
        IResult Update(IFormFile file, ProductImageModel productImage);
        IDataResult<ProductImageModel> GetForShowCase();

    }
}