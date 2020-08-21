using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Cognizant.Truyum.Dao
{
    public class CommandHelper
    {
        

        public static string MenuItemListAdmin { get => "SELECT * FROM menu_item";  }
        public static string MenuItemListCustomer { get => "SELECT * FROM menu_item where menu_active='1' and menu_dol > GETDATE()"; }
        public static string GetMenuItem { get => "SELECT * FROM menu_item where menu_id = @id"; }
        public static string ModifyMenuItem { get => "UPDATE menu_item SET menu_name=@name, menu_price =@price, menu_active=@active, menu_dol=@date, menu_category=@category,menu_free_delivery=@delivery where menu_id = @id "; }

        public static string AddCartItem { get => "INSERT INTO cart(cart_id,cart_us_id,cart_pr_id) VALUES (@cartid,@userid,@menuid)"; }
        public static string GetAllCartItems { get => "SELECT menu_id,menu_name,menu_price,menu_active,menu_dol,menu_category,menu_free_delivery  FROM menu_item m join cart c on m.menu_id=c.cart_pr_id where c.cart_us_id=@inputid;"; }
        public static string RemoveCartItems { get => "DELETE FROM CART where cart_us_id = @userid and cart_pr_id = @menuitemid "; }
    }
}
