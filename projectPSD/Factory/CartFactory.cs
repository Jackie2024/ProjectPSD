using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Factory
{
    public class CartFactory
    {
        public static Carts Create(int quantity, Products product)
        {
            Carts cart = new Carts()
            {
                Quantity = quantity,
                Products = product
            };
            return cart;
        }
    }
}