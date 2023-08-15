using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
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
        public void AddWithImage(Product product, List<ProductImageModel> images)
        {
            using (ETradeDbContext context = new ETradeDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Products.Add(product);
                        context.SaveChanges();

                        foreach (var image in images)
                        {
                            image.ProductId = (int)product.ImageId;
                            context.ProductImages.Add(image);
                        }
                        context.SaveChanges();

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public ProductDetailDto GetProductDetail(int productId)
        {
            using (ETradeDbContext context = new ETradeDbContext())
            {
                bool x = false;
                var result = (from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.Id
                              join i in context.ProductImages
                              on p.Id equals i.ProductId
                              select new ProductDetailDto
                             {
                                 CategoryName = c.CategoryName,
                                 ProductId = (int)p.Id,
                                 ProductName = p.ProductName,
                                 UnitPrice = (decimal)p.UnitPrice,
                                 Description = p.Description,
                                 Header = p.Header,
                                 UnitsInStock = (int)p.UnitsInStock,
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

        public List<ProductDetailDto> GetProductsForShowCase()
        {
            using (ETradeDbContext context = new ETradeDbContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.Id
                             join i in context.ProductImages
                             on p.ImageId equals i.ProductId
                             where p.ShowCase==true && i.IsMain==true
                             select new ProductDetailDto
                             {
                                 CategoryName = c.CategoryName,
                                 ProductId = (int)p.Id,
                                 ProductName = p.ProductName,
                                 UnitPrice = (decimal)p.UnitPrice,
                                 Description = p.Description,
                                 Header = p.Header,
                                 UnitsInStock = (int)p.UnitsInStock,
                                 UploadTime = p.UploadTime,
                                 ImageContentType = i.ContentType,
                                 ImageData = i.Data,
                             };
                return result.ToList();
            }
        }

        public List<ProductDetailDto> ProductsList()
        {
            using (ETradeDbContext context = new ETradeDbContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.Id
                             join i in context.ProductImages
                             on p.ImageId equals i.ProductId
                             where i.IsMain == true
                             select new ProductDetailDto
                             {
                                 ProductName = p.ProductName,
                                 UnitPrice = (decimal)p.UnitPrice,
                                 CategoryName = c.CategoryName,
                                 Description = p.Description,
                                 Header = p.Header,
                                 ImageContentType = i.ContentType,
                                 ImageData = i.Data,
                                 UnitsInStock = (int)p.UnitsInStock,
                                 UploadTime = p.UploadTime,

                             };
                if (result.ToList()!=null)
                {
                    return result.ToList();
                }
                return null;
                
            }
        }
    }
}
