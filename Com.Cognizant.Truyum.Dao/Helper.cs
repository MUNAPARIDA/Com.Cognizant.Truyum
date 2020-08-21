using System.Configuration;
using System.Collections.Generic;
using System.Text;
using System;
namespace Com.Cognizant.Truyum.Dao
{
    public class Helper
    {

        public static string ConnectionString { get => ConfigurationManager.ConnectionStrings["connectionString"].ToString();}
    }
}
