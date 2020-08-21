using Com.Cognizant.Truyum.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Threading;

namespace Com.Cognizant.Truyum.Dao
{
    public  class MenuItemDaoSql : IMenuItemDao
    {
        private SqlConnection sqlConnection;
        private SqlCommand sqlCommand;
        private SqlDataReader sqlDataReader;
       
        
        public MenuItem GetMenuItem(long menuItemId)
        {
            MenuItem menuItems = null;
            using (sqlConnection = new SqlConnection(Helper.ConnectionString))
            {
                using (sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = CommandHelper.GetMenuItem;
                    sqlCommand.Parameters.AddWithValue("@id", menuItemId);
                    sqlConnection.Open();
                    sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        menuItems = new MenuItem()
                        {

                            ID = int.Parse(sqlDataReader[0].ToString()),
                            Name = sqlDataReader[1].ToString(),
                            Price = float.Parse(sqlDataReader[2].ToString()),
                            Active = bool.Parse(sqlDataReader[3].ToString()),
                            DateOfLaunch = Utility.Utility.ConvertToDate(sqlDataReader[4].ToString()),
                            Category = sqlDataReader[5].ToString(),
                            FreeDelivery = bool.Parse(sqlDataReader[6].ToString())
                        };
                    }
                }
            }
            return menuItems;
        }

        public List<MenuItem> GetMenuItemListCustomer()
        {
            List<MenuItem> menuItems = new List<MenuItem>();
            using (sqlConnection = new SqlConnection(Helper.ConnectionString))
            {
                using (sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = CommandHelper.MenuItemListCustomer;
                    sqlConnection.Open();
                    sqlDataReader = sqlCommand.ExecuteReader();
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
                        }
                            );
                    }
                }
            }
            return menuItems;
        }

        public void ModifyMenuItem(MenuItem menuItem)
        {
            using (sqlConnection = new SqlConnection(Helper.ConnectionString))
            {
                using (sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = CommandHelper.ModifyMenuItem;
                    sqlCommand.Parameters.AddWithValue("@id", menuItem.ID);
                    sqlCommand.Parameters.AddWithValue("@name", menuItem.Name);
                    sqlCommand.Parameters.AddWithValue("@price", menuItem.Price);
                    sqlCommand.Parameters.AddWithValue("@active", menuItem.Active);
                    sqlCommand.Parameters.AddWithValue("@date", Utility.Utility.ConvertToString(menuItem.DateOfLaunch));
                    sqlCommand.Parameters.AddWithValue("@category", menuItem.Category);
                    sqlCommand.Parameters.AddWithValue("@delivery", menuItem.FreeDelivery);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    
                }

            }
        }

        public List<MenuItem> GetMenuItemListAdmin()
        {
            List<MenuItem> menuItems = new List<MenuItem>();
            using (sqlConnection = new SqlConnection(Helper.ConnectionString))
            {
                using (sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText = CommandHelper.MenuItemListAdmin;
                    sqlConnection.Open();
                    sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        menuItems.Add( new MenuItem() {
                       
                            ID = int.Parse(sqlDataReader[0].ToString()),
                            Name = sqlDataReader[1].ToString(),
                            Price = float.Parse(sqlDataReader[2].ToString()),
                            Active = bool.Parse(sqlDataReader[3].ToString()),
                            DateOfLaunch = Utility.Utility.ConvertToDate(sqlDataReader[4].ToString()),
                            Category = sqlDataReader[5].ToString(),
                            FreeDelivery = bool.Parse(sqlDataReader[6].ToString())
                        }
                            );
                    }
                }
            }
            return menuItems;
        }

        
    }
}
