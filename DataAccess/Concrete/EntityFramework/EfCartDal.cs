using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCartDal : EfEntityRepositoryBase<Cart, ETradeDbContext>, ICartDal
    {

        public List<CartProductDetailDto> GetByProductIdAndCustomerId(string customerId)
        {
            using (ETradeDbContext context = new ETradeDbContext())
            {
                var result = from prod in context.Products
                             join cat in context.Categories
                             on prod.CategoryId equals cat.Id
                             join imag in context.ProductImages
                             on prod.ImageId equals imag.ProductId
                             join cart in context.Carts
                             on prod.Id equals cart.ProductId
                             join customer in context.Customers
                             on customerId equals customer.UniqueId
                             where customer.UniqueId == customerId && imag.IsMain == true
                             select new CartProductDetailDto
                             {
                                 ProductId = prod.Id,
                                 CartId = cart.Id,
                                 Size = cart.Size,
                                 UnitsInStock = (int)prod.UnitsInStock,
                                 CategoryName = cat.CategoryName,
                                 Header = prod.Header,
                                 ImageContentType = imag.ContentType,
                                 ImageData = imag.Data,
                                 ProductName = prod.ProductName,
                                 UnitPrice = (decimal)prod.UnitPrice,
                                 Sizes=prod.Sizes,
                             };
                return result.ToList();
            }
        }
    }
}
