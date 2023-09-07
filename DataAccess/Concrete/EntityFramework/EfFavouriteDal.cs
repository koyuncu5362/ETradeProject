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
                             where img.IsMain == true && customerId==fav.CustomerId
                             select new FavouritesDetailDto
                             {
                                 Header = prod.Header,
                                 ImageContentType = img.ContentType,
                                 ImageData = img.Data,
                                 ProductName = prod.ProductName,
                                 UnitPrice = (decimal)prod.UnitPrice,
                                 Size = fav.ProductSize
                             };
                return result.ToList();
            }
        }
    }
}
