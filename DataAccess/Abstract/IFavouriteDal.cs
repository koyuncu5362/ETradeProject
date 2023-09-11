using Core.DataAccess;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IFavouriteDal:IEntityRepository<Favourite>
    {
        List<FavouritesDetailDto> GetFavourites(string customerId);
        Favourite GetByProductIdAndCustomerId(int productId, string customerId);
        void DeleteByCustomerIdAndProductId(int productId, string customerId);
    }
}
