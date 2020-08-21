using Com.Cognizant.Truyum.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Cognizant.Truyum.Dao
{
    public class MenuItemDaoCollection : IMenuItemDao
    {
        List<MenuItem> menuItemList;

        public MenuItemDaoCollection(List<MenuItem> list)
        {
            if (menuItemList == null)
            {
                menuItemList = new List<MenuItem>();
                menuItemList.Add( new MenuItem()
                {
                    ID = 8001,
                    Name = "Sandwich",
                    Price = 99.00,
                    Active = true,
                    DateOfLaunch = new DateTime(2017, 05, 13),
                    Category = "Main Course",
                    FreeDelivery = true
                });
                menuItemList.Add( new MenuItem()
                { 
                    ID= 8002,
                    Name="Burger",
                    Price=  129.00,Active= true, 
                    DateOfLaunch= new DateTime(2017, 12, 23), 
                    Category="Main Course",
                    FreeDelivery= false  
                });
                menuItemList.Add( new MenuItem() 
                {
                    ID= 8003,
                    Name= "Pizza",
                    Price= 149.00,
                    Active= true,
                    DateOfLaunch= new DateTime(2018, 08, 21),
                    Category= "Main Course",
                    FreeDelivery= false 
                });
                menuItemList.Add(new MenuItem()
                {
                    ID = 8004,
                    Name = "French Fries",
                    Price = 57.00,
                    Active = false,
                    DateOfLaunch = new DateTime(2017, 07, 02),
                    Category = "Starters",
                    FreeDelivery = true
                });
                menuItemList.Add(new MenuItem(){
                    ID=8005,
                    Name="Chocolate Brownie",
                    Price=32.00,
                    Active=true,
                    DateOfLaunch=new DateTime(2022, 11, 02),
                    Category="Dessert",
                    FreeDelivery=true 
                });
            }
            else if(list != null)
                menuItemList.AddRange(list);
        }
        public List<MenuItem> GetMenuItemListAdmin()
        {
            return this.menuItemList;
        }

        public MenuItem GetMenuItem(long menuItemId)
        {
            if (menuItemList != null)
            {
                foreach (var item in menuItemList)
                {
                    if(item.ID == menuItemId)
                    {
                        return item;
                    }

                }
            }
            return null;
        }


        public List<MenuItem> GetMenuItemListCustomer()
        {
            List<MenuItem> menuItems = new List<MenuItem>();
            foreach (var item in menuItemList)
            {
                if (item.DateOfLaunch.Date > DateTime.Today.Date && item.Active == true)
                    menuItems.Add(item);
            }
            return menuItems;
        }


        public void ModifyMenuItem(MenuItem menuItem)
        {
            if (menuItemList != null && menuItem != null)
            {
                foreach (var item in menuItemList)
                {
                    if (item.Equals(menuItem))
                    {
                        item.Name = menuItem.Name;
                        item.Price = menuItem.Price;
                        item.Active = menuItem.Active;
                        item.DateOfLaunch = menuItem.DateOfLaunch;
                        item.Category = menuItem.Category;
                        item.FreeDelivery = menuItem.FreeDelivery;
                    }
                }
            }
        }
    }
}
