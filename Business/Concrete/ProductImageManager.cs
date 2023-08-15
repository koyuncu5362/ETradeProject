using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductImageManager : IProductImageService
    {
        IProductImageDal _productImageDal;
        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }
        public IResult Add(ProductImageModel productImage)
        {
            _productImageDal.Add(productImage);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(ProductImageModel productImage)
        {
            throw new NotImplementedException();
        }

        public IResult Update(IFormFile file, ProductImageModel productImage)
        {
            throw new NotImplementedException();
        }
    }
}
