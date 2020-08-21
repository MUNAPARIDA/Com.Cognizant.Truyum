using Com.Cognizant.Truyum.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Cognizant.Truyum.Dao
{
    public class MenuItemDaoCollectionTest
    {
       
        public static void TestGetMenuItemListAdmin()
        {
            List<MenuItem> sample = null;
            IMenuItemDao menuItemDao = new MenuItemDaoCollection(sample);
            sample = menuItemDao.GetMenuItemListAdmin();
            
            foreach (var item in sample)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static void TestModifyMenuItem()
        {
            List<MenuItem> sample = null;
            MenuItem item = new MenuItem() { ID= 8002, Name="Swarma",Price= 100.25,Active= true,DateOfLaunch= new DateTime(1997, 07, 22),Category= "Snacks",FreeDelivery= false
                };
            IMenuItemDao menuItemDao = new MenuItemDaoCollection(sample);
            menuItemDao.ModifyMenuItem(item);
            MenuItem extractedItem  = menuItemDao.GetMenuItem(8002);
            Console.WriteLine(extractedItem.ToString());
        }




    }
}
