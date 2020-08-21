using Com.Cognizant.Truyum.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Cognizant.Truyum.Dao
{
    public interface ICartDao
    {
        public void AddCartItem(long userId, long menuItemId);
        public Cart GetAllCartItems(long userId);
        public void RemoveCartItems(long userId, long productId);

    }
}