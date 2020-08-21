using Com.Cognizant.Truyum.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Cognizant.Truyum.Dao
{
    public class CartDaoCollectionTest
    {
        public static void TestAddCartItem()
        {

            Dictionary<long, Cart> dictionary = null;
            ICartDao cartDao = new CartDaoCollection(dictionary);
            cartDao.AddCartItem(1,8002);
            Cart cart = cartDao.GetAllCartItems(1);
            List<MenuItem> list = cart.MenuItemList;
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());

            }
            Console.WriteLine(cart.Total);
        }
        public static void TestRemoveCartItem()
        {
            Dictionary<long, Cart> dictionary = null;
            ICartDao cartDao = new CartDaoCollection(dictionary);
            cartDao.RemoveCartItems(1, 8002);
            Cart cart = cartDao.GetAllCartItems(1);
            List<MenuItem> list = cart.MenuItemList;
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());

            }
            Console.WriteLine(cart.Total);

        }
    }
}
