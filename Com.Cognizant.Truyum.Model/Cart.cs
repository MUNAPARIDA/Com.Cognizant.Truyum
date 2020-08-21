using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Cognizant.Truyum.Model
{
    public class Cart
    {
        private List<MenuItem> menuItemList;
        private double total;

        public List<MenuItem> MenuItemList { get => menuItemList; set => menuItemList = value; }

        public double Total { get => total; set => total = value; }

        public Cart(List<MenuItem> list,double total)
        {
            MenuItemList = list;
            Total = total;
        }
    }
}
