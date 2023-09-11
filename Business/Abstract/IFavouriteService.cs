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
    public interface IFavouriteService
    {
        IResult Add(Favourite favourite);
        IResult Delete(Favourite favourite);
        IDataResult<List<FavouritesDetailDto>> GetAllFavourite(string customerId);
        IDataResult<Favourite> GetById(int productId, string customerId);
        IResult DeleteByCustomerIdAndProductId(int productId, string customerId);
    }
}
