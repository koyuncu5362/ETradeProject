using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfFavouriteDal : EfEntityRepositoryBase<Favourite, ETradeDbContext>, IFavouriteDal
    {

        public List<FavouritesDetailDto> GetFavourites(string customerId)
        {
            using (ETradeDbContext context = new ETradeDbContext())
            {
                var result = from prod in context.Products
                             join fav in context.Favourites
                             on prod.Id equals fav.ProductId
                             join cus in context.Customers
                             on fav.CustomerId equals cus.UniqueId
                             join img in context.ProductImages
                             on prod.ImageId equals img.ProductId
                             join cat in context.Categories
                             on prod.CategoryId equals cat.Id
                             where img.IsMain == true && customerId==fav.CustomerId
                             select new FavouritesDetailDto
                             {
                                 Id=fav.Id,
                                 CategoryName=cat.CategoryName,
                                 ProductId = (int)prod.Id,
                                 Header = prod.Header,
                                 ImageContentType = img.ContentType,
                                 ImageData = img.Data,
                                 ProductName = prod.ProductName,
                                 UnitPrice = (decimal)prod.UnitPrice,
                             };
                return result.ToList();
            }
        }
        public Favourite GetByProductIdAndCustomerId(int productId, string customerId)
        {
            using (ETradeDbContext context = new ETradeDbContext())
            {
                var result = from fav in context.Favourites
                             where fav.ProductId == productId && fav.CustomerId == customerId
                             select new Favourite
                             {
                                 Id = fav.Id,
                                 CustomerId = customerId,
                                 ProductId = fav.ProductId,
                             };
                if (result.ToList().Count>1)
                {
                    return null;
                }
                else if (result != null && result.Any())
                {
                    return result.Single();
                }
                else
                {
                    return null;
                }
            }
        }

        public void DeleteByCustomerIdAndProductId(int productId, string customerId)
        {
            using (ETradeDbContext context = new ETradeDbContext())
            {
                var favouritesToDelete = context.Favourites
           .Where(fav => fav.ProductId == productId && fav.CustomerId == customerId)
           .ToList(); // Verileri liste olarak alın.

                foreach (var favourite in favouritesToDelete)
                {
                    context.Entry(favourite).State = EntityState.Deleted; // Her bir veriyi silme durumuna getirin.
                }

                context.SaveChanges();
            }
        }

    }
}
