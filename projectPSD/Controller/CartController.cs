using ProjectPSD.Handler;
using ProjectPSD.Model;
using ProjectPSD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectPSD.Controller
{
    public class CartController
    {
        public string validateCart(int stock, string stockString, Products p)
        {
            String errMsg = null;
            int myInt;
            bool isNumerical = Int32.TryParse(stockString, out myInt);
            if (!isNumerical)
            {
                errMsg = "Input must be numeric";
            }
            else if (stock < 1)
            {
                errMsg = "Stock Must be more than 0";
            }
            else if (stock > p.Stock)
            {
                errMsg = "Stock must be less than or equals to current stock";
            }
            return errMsg;
        }

        public static double GrandTotal(int userId)
        {
            return CartHandler.GrandTotal(userId);
        }

        public static List<Object> getCurrUserCarts(int userId)
        {
            return CartRepository.getCurrUserCarts(userId);
        }


        public static List<Object> generateProductData(int productID)
        {
            return CartHandler.getProductDetails(productID);
        }

        public static string updateValidation(int quantity, int stock, int id)
        {
            string errorMsg = "";
            CartHandler cart = new CartHandler();
            Products p = new Products();
            p = CartHandler.getProductID(id);
            if (quantity < 0)
            {
                errorMsg = "quantity cannot be less than 0";
            }else if (quantity > stock)
            {
                errorMsg = "quantity cannot be more than stock";
            }

            return errorMsg;
        }

        public static Products getProductByID(int id)
        {
            return CartHandler.getProductID(id);
        }
    }
}