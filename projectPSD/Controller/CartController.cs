using ProjectPSD.Handler;
using ProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Controller
{
    public class CartController
    {
        public static List<Object> generateProductData(int productID)
        {
            return CartHandler.getProductDetails(productID);
        }

       
    }
}