using Com.Cognizant.Truyum.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Cognizant.Truyum.Dao
{
   public class MenuItemDaoTest
    {   
        public static void TestGetMenuItemListCustomer()
        {
            List<MenuItem> sample = null;
            IMenuItemDao menuItemDao = new MenuItemDaoCollection(sample);
            sample = menuItemDao.GetMenuItemListCustomer();
            foreach (var item in sample)
            {
                Console.WriteLine(item.ToString());
            }
        }

    }
}
