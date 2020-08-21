using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Cognizant.Truyum.Dao;
using Com.Cognizant.Truyum.Utility;

namespace ConsoleProgram
{
    public class Program
    {
       public  static void Main(string[] args)
        {
            MenuItemDaoCollectionTest.TestGetMenuItemListAdmin();

            Console.WriteLine("-------------------------------------------------");

            MenuItemDaoTest.TestGetMenuItemListCustomer();

            Console.WriteLine("-------------------------------------------------");

            MenuItemDaoCollectionTest.TestModifyMenuItem();

            Console.WriteLine("-------------------------------------------------");

            CartDaoCollectionTest.TestAddCartItem();

            Console.WriteLine("-------------------------------------------------");

            CartDaoCollectionTest.TestRemoveCartItem();

            Console.WriteLine("-------------------------------------------------");

            Console.WriteLine(Utility.ConvertToString(DateTime.Today.Date));
        }
    }
}
