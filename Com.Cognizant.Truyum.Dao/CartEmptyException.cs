using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Cognizant.Truyum.Dao
{
    public class CartEmptyException : System.Exception
    {
        public CartEmptyException(string message) : base(message)
        {
            /*Console.WriteLine(message);*/
        }
    }
}
