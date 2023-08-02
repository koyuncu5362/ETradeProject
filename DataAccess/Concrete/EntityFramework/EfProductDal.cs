using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, ETradeDbContext>, IProductDal
    {
        public ProductDetailDto GetProductDetail(int productId)
        {
            using (ETradeDbContext context = new ETradeDbContext())
            {
                bool x = false;
                var result = (from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.Id
                             join t in context.ProductTexts
                             on p.ProductTextId equals t.Id
                             select new ProductDetailDto
                             {
                                 CategoryName = c.CategoryName,
                                 ProductId = p.Id,
                                 ProductName = p.ProductName,
                                 UnitPrice = p.UnitPrice,
                                 Description = t.Description,
                                 Header = t.Header,
                                 UnitsInStock = p.UnitsInStock,
                                 UploadTime = p.UploadTime,
                             }).ToList();
                for (int i = 0; i < result.Count; i++)
                {
                    if (result[i].ProductId==productId)
                    {
                        return result[i];
                    }
                }
                return null;          
            }
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            using (ETradeDbContext context = new ETradeDbContext())
            {
                var result = from p in context.Products
                             join t in context.ProductTexts
                             on p.ProductTextId equals t.Id
                             join c in context.Categories
                             on p.CategoryId equals c.Id
                             select new ProductDetailDto
                             {
                                 CategoryName = c.CategoryName,
                                 ProductId = p.Id,
                                 ProductName = p.ProductName,
                                 UnitPrice = p.UnitPrice,
                                 Description = t.Description,
                                 Header = t.Header,
                                 UnitsInStock = p.UnitsInStock,
                                 UploadTime = p.UploadTime,
                             };
                return result.ToList();
            }
        }
    }
}
