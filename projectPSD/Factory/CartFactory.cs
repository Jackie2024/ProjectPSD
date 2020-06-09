using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Factory
{
    public class CartFactory
    {
        public static Carts Create(int userId, int quantity, Products product)
        {
            Carts cart = new Carts();
            cart.Quantity = quantity;
            cart.ProductID = product.ID;
            cart.UserID = userId;
            return cart;
        }
    }
}