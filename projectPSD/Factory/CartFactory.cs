using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Factory
{
    public class CartFactory
    {
        public static Carts Create(int quantity, int userID, int productID)
        {
            Carts cart = new Carts()
            {
                UserID = userID,
                Quantity = quantity,
                ProductID = productID
            };
            return cart;
        }
    }
}