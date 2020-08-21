using Com.Cognizant.Truyum.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;

namespace Com.Cognizant.Truyum.Dao
{
    public class CartDaoCollection : ICartDao
    {
        Dictionary<long,Cart> userCarts;

        public CartDaoCollection(Dictionary<long,Cart> dictionary)
        {
            if(userCarts == null)
            {
                userCarts = new Dictionary<long, Cart>();
                List<MenuItem> list1 = new List<MenuItem>();
                List<MenuItem> list2 = new List<MenuItem>();
                list1.Add(new MenuItem()
                {
                    ID = 8001,
                    Name = "Sandwich",
                    Price = 99.00,
                    Active = true,
                    DateOfLaunch = new DateTime(2017, 05, 13),
                    Category = "Main Course",
                    FreeDelivery = true
                });
                list1.Add(new MenuItem()
                {
                    ID = 8003,
                    Name = "Pizza",
                    Price = 149.00,
                    Active = true,
                    DateOfLaunch = new DateTime(2018, 08, 21),
                    Category = "Main Course",
                    FreeDelivery = false
                });
                userCarts.Add(1, new Cart( list1 ,248.00));
                list2.Add(new MenuItem()
                {
                    ID = 8004,
                    Name = "French Fries",
                    Price = 57.00,
                    Active = false,
                    DateOfLaunch = new DateTime(2017, 07, 02),
                    Category = "Starters",
                    FreeDelivery = true
                });
                list2.Add(new MenuItem()
                {
                    ID = 8005,
                    Name = "Chocolate Brownie",
                    Price = 32.00,
                    Active = true,
                    DateOfLaunch = new DateTime(2022, 11, 02),
                    Category = "Dessert",
                    FreeDelivery = true
                });
                userCarts.Add(2, new Cart(list2, 89.00));

            }
            else if(dictionary != null)
            {
                foreach (KeyValuePair<long,Cart> item in dictionary)
                {
                    userCarts[item.Key] = item.Value;
                }
            }
           
        }
        public void AddCartItem(long userId, long menuItemId)
        {
            List<MenuItem> newItem = null;
            IMenuItemDao menuItemDao = new MenuItemDaoCollection(newItem);
            MenuItem menuItem = menuItemDao.GetMenuItem(menuItemId);            
            bool flag = false;
            foreach (KeyValuePair<long,Cart> item in userCarts)
            {
                if(item.Key == userId)
                {
                    flag = true;
                    Cart cart = item.Value;
                    cart.MenuItemList.Add(menuItem);                                      
                }

            }
            if (!flag)
            {
                userCarts.Add(userId, new Cart(new List<MenuItem>() {menuItem}, menuItem.Price));
            }
            
        }
        public Cart GetAllCartItems(long userId)
        {
            Cart cart = null;
            double temp = 0;
            foreach (KeyValuePair<long,Cart> item in userCarts)
            {
                if (item.Key == userId)
                    cart = item.Value;
            }
            if (cart == null)
                throw new CartEmptyException("Cart is empty.");
            else
            {
                foreach (var item in cart.MenuItemList)
                {
                    temp += item.Price;
                }
                cart.Total = temp;
            }
            return cart;
        }

        public void RemoveCartItems(long userId, long productId)
        {
            Cart cart = null;
            foreach (KeyValuePair<long, Cart> item in userCarts)
            {
                if (item.Key == userId)
                    cart = item.Value;
            }
            if (cart == null)
                throw new CartEmptyException("Cart is empty.");
            else
            {
                var item = cart.MenuItemList.SingleOrDefault(x => x.ID == productId);
                cart.MenuItemList.Remove(item);
            }


        }
    }
}
