using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Factory
{
    public class ProductFactory
    {
        public static Products createProduct(String name, int stock, int price)
        {
            return new Products()
            {
                ProductTypeID = 6,
                Name = name,
                Stock = stock,
                Price = price
            };
        }
    }
}