using Com.Cognizant.Truyum.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Cognizant.Truyum.Dao
{
    public interface IMenuItemDao
    {
        public List<MenuItem> GetMenuItemListAdmin();
        public List<MenuItem> GetMenuItemListCustomer();
        public void ModifyMenuItem(MenuItem menuItem);
        public MenuItem GetMenuItem(long menuItemId);
    }
}
