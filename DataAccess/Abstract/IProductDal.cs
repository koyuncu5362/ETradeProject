using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductDetailDto> GetProductDetail(int productId);
        List<ProductDetailDto> GetProductsForShowCase();
        List<ProductDetailDto> ProductsList();
        void AddWithImage(Product product, List<ProductImageModel> images);
    }
}
