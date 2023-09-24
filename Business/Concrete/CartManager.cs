using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CartManager : ICartService
    {
        ICartDal cartDal;
        public CartManager(ICartDal _cartDal)
        {
            cartDal = _cartDal;
        }
        public IResult Add(Cart cart)
        {
            cartDal.Add(cart);
            return new SuccessResult(Messages.CartAdded);
        }

        public IResult Delete(Cart cart)
        {
            cartDal.Delete(cart);
            return new SuccessResult(Messages.CartDeleted);
        }

        public IDataResult<List<CartProductDetailDto>> GetCarts(string customerId)
        {
            var result = cartDal.GetByProductIdAndCustomerId(customerId);
            return new SuccessDataResult<List<CartProductDetailDto>>(result);
        }
    }
}
