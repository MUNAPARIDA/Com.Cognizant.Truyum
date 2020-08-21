using Com.Cognizant.Truyum.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace Com.Cognizant.Truyum.Dao
{
    public class CartDaoSql : ICartDao
    {
        private int count=0;
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataReader sqlDataReader;
        public void AddCartItem(long userId, long menuItemId)
        {
            using (sqlConnection = new SqlConnection(Helper.ConnectionString))
            {
                using (sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = CommandHelper.AddCartItem;
                    sqlCommand.Parameters.AddWithValue("@cartid", ++count);
                    sqlCommand.Parameters.AddWithValue("@userid", userId);
                    sqlCommand.Parameters.AddWithValue("@menuid", menuItemId);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public Cart GetAllCartItems(long userId)
        {
            double totalprice = 0;
            List<MenuItem> menuItems = new List<MenuItem>();
            using (sqlConnection = new SqlConnection(Helper.ConnectionString))
            {
                using (sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = CommandHelper.GetAllCartItems;
                    sqlCommand.Parameters.AddWithValue("@inputid", userId);    
                    sqlConnection.Open();
                    sqlDataReader= sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        menuItems.Add(new MenuItem()
                        {
                            ID = int.Parse(sqlDataReader[0].ToString()),
                            Name = sqlDataReader[1].ToString(),
                            Price = float.Parse(sqlDataReader[2].ToString()),
                            Active = bool.Parse(sqlDataReader[3].ToString()),
                            DateOfLaunch = Utility.Utility.ConvertToDate(sqlDataReader[4].ToString()),
                            Category = sqlDataReader[5].ToString(),
                            FreeDelivery = bool.Parse(sqlDataReader[6].ToString())

                        });
                    }
                    foreach (var item in menuItems)
                    {
                        totalprice += item.Price;
                    }
                    
                }
            }
            Cart cart = new Cart(menuItems, totalprice);
            return cart;
        }

        public void RemoveCartItems(long userId, long productId)
        {
            using (sqlConnection = new SqlConnection(Helper.ConnectionString))
            {
                using (sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = CommandHelper.RemoveCartItems;
                    sqlCommand.Parameters.AddWithValue("@userid", userId);
                    sqlCommand.Parameters.AddWithValue("@menuitemid", productId);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
