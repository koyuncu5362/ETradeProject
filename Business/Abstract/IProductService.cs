using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategory(int categoryId);
        IDataResult<Product> GetById(int id);
        IDataResult<List<ProductDetailDto>> GetProductsDetails();
        IDataResult<List<ProductDetailDto>> GetProductsDetailsforShowCase();
        IDataResult<List<ProductDetailDto>> GetProductDetail(int productId);
        IResult Add(Product product);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IResult Update(Product product);
        IResult Delete(Product product);
        IResult AddWithImage(Product product, List<ProductImageModel> images);
    }
}
